# Waypoint Python Server for webosckets. It send 3 waypoints at first and then deletes 1, then loops again and again.
# Steps:
# Run this file in VSCode and AFTER run your unity scene
# Update buttons UI to these waypoints using the scroll handler provided
# Use the event system to subscribe

import asyncio
import websockets # If this gives a warning/error, open command line and do 'pip install websockets'
import json

async def send_data_initial(websocket):
    data = {
        "id": "1",
        "type": "Messaging",
        "use": "PUT",
        "data": {
            "AllMessages": [
                {
                    "id": 1,
                    "sent_to": 2,
                    "message": "Hello, how are you?",
                    "from": 1
                },
                {
                    "id": 2,
                    "sent_to": 1,
                    "message": "I'm doing well, thanks!",
                    "from": 2
                },
                {
                    "id": 3,
                    "sent_to": 2,
                    "message": "Can you please send me the report?",
                    "from": 1
                }
            ]
        }
    }


    # Convert the data to a JSON string
    message = json.dumps(data)

    # Send the JSON message to the connected client (Unity)
    await websocket.send(message)

async def send_data_added(websocket):
    data = {
        "id": "1",
        "type": "Messaging",
        "use": "PUT",
        "data" : {
            "AllMessages": [
                {
                    "id": 1,
                    "sent_to": 2,
                    "message": "Hello, how are you?",
                    "from": 1
                },
                {
                    "id": 2,
                    "sent_to": 1,
                    "message": "I'm doing well, thanks!",
                    "from": 2
                },
                {
                    "id": 3,
                    "sent_to": 2,
                    "message": "Can you please send me the report?",
                    "from": 1
                },
                {
                    "id": 4,
                    "sent_to": 1,
                    "message": "No I cannot, I am stuck",
                    "from": 2
                }
            ]
        }
    }

    # Convert the data to a JSON string
    message = json.dumps(data)

    # Send the JSON message to the connected client (Unity)
    await websocket.send(message)

async def send_data_deleted(websocket):
    data = {
        "id": "1",
        "type": "Messaging",
        "use": "PUT",
        "data" : {
            "AllMessages": [
                {
                    "id": 1,
                    "sent_to": 2,
                    "message": "Hello, how are you?",
                    "from": 1
                },
                {
                    "id": 4,
                    "sent_to": 1,
                    "message": "No I cannot, I am stuck",
                    "from": 2
                }
            ]
        }
    }

    # Convert the data to a JSON string
    message = json.dumps(data)

    # Send the JSON message to the connected client (Unity)
    await websocket.send(message)

async def handle_client(websocket, path):
    try:
        while True:
            await send_data_initial(websocket)
            await asyncio.sleep(5)
            await send_data_added(websocket)
            await asyncio.sleep(5)
            await send_data_deleted(websocket)
            await asyncio.sleep(5)
    except websockets.exceptions.ConnectionClosed:
        pass

start_server = websockets.serve(handle_client, "localhost", 8080)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()

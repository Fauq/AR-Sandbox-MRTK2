using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
Name: Emily Song
Description: I have not a clue what this is and what this does >:(
 */

public class MessagingController : MonoBehaviour
{

    private Subscription<MessagesDeletedEvent> messagesDeletedEvent;
    private Subscription<MessagesEditedEvent> messagesEditedEvent;
    private Subscription<MessagesAddedEvent> messagesAddedEvent;

    //ADDED STUFF EMILY
    public GameObject messageButtonPrefab; // Reference to your button prefab
    public Transform buttonListParent;
    public List<GameObject> messageList = new List<GameObject>(); // List to store buttons
    public List<int> idList = new List<int>(); //List to store Message indices
    //private ScrollHandler scrollHandler = GameObject.Find("ScrollObjects").GetComponent<ScrollHandler>();
    private ScrollHandler scrollHandler;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the events
        messagesDeletedEvent = EventBus.Subscribe<MessagesDeletedEvent>(OnMessagesDeleted);
        messagesEditedEvent = EventBus.Subscribe<MessagesEditedEvent>(OnMessagesEdited);
        messagesAddedEvent = EventBus.Subscribe<MessagesAddedEvent>(OnMessagesAdded);
    }

    void OnDestroy()
    {
        // Unsubscribe when the script is destroyed
        if (messagesDeletedEvent != null)
        {
            EventBus.Unsubscribe(messagesDeletedEvent);
        }
        if (messagesEditedEvent != null)
        {
            EventBus.Unsubscribe(messagesEditedEvent);
        }
        if (messagesAddedEvent != null)
        {
            EventBus.Unsubscribe(messagesAddedEvent);
        }
    }

    private void OnMessagesDeleted(MessagesDeletedEvent e)
    {
        //Debug.Log("Deleted");
        List<Message> deletedMessages = e.DeletedMessages; // Which messages were deleted (Look at their id's)
        // Update the UI to reflect the deleted messages
        foreach (Message message in deletedMessages)
        {
            //could do binary search here
            index = idList.BinarySearch(message.id);
        }
    }

    private void OnMessagesEdited(MessagesEditedEvent e)
    {
        //Debug.Log("Edited");
        List<Message> editedMessages = e.EditedMessages; // Which messages were edited (Look at their id's)
        // Update the UI to reflect the edited messages
        //foreach (Message message in editedMessages)
        //{
        //    GameObject button = messageList.Find(x => x.Find("Button"). == message.id);
        //}

    }

    private void OnMessagesAdded(MessagesAddedEvent e)
    {
        //Debug.Log("Added");
        List<Message> newAddedMessages = e.NewAddedMessages; // Which messages are new
        // Update the UI to reflect the new messages
        foreach (Message message in newAddedMessages)
        {

            //GameObject newButton = messageButtonPrefab;
            //newButton.
            //scrollHandler.HandleAddingButton(newButton)
        }
    }
}

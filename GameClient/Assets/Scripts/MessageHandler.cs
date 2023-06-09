using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    private static MessageHandler _current;

    private void Awake() {
        if (_current == null)
            _current = this;
        else
            Destroy(gameObject);
    }

    public delegate void OnMessageJoinedGameHandler(MessageJoinedGame messageJoinedGame);
    public delegate void OnMessagePlayerMovedHandler(MessagePlayerMoved messagePlayerMoved);
    public delegate void OnMessageLeftGameHandler(MessageLeftGame messageLeftGame);
    public delegate void OnMessageGameStateHandler(MessageGameState messageGameState);
    public delegate void OnMessageAttackedHandler(MessageAttacked messageAttacked);
    public delegate void OnMessageDespawnObjectHandler(MessageDespawnObject messageDespawnObject);
    public delegate void OnMessageSpawnNodesHandler(MessageSpawnNodes messageSpawnNodes);
    public delegate void OnMessageNPCMovedHandler(MessageNPCMoved messageNPCMoved);
    public delegate void OnMessageSpawnNPCsHandler(MessageSpawnNPCs messageSpawnNPCs);
    public delegate void OnMessageInventoryAddHandler(MessageInventoryAdd messageInventoryAdd);
    public delegate void OnMessageInventoryRemoveHandler(MessageInventoryRemove messageInventoryRemove);
    public delegate void OnMessageCraftedHandler(MessageCrafted messageCrafted);
    public delegate void OnMessageHealthChangedHandler(MessageHealthChanged messageHealthChanged);
    public delegate void OnMessageChannelHandler(MessageChannel messageChannel);
    public delegate void OnMessageCastHandler(MessageCast messageCast);
    public delegate void OnMessageStopActivityHandler(MessageStopActivity messageStopActivity);
    public delegate void OnMessageExperienceChangedHandler(MessageExperienceChanged messageExperienceChanged);

    private event OnMessageJoinedGameHandler _onMessageJoinedGame;
    private event OnMessagePlayerMovedHandler _onMessagePlayerMoved;
    private event OnMessageLeftGameHandler _onMessageLeftGame;
    private event OnMessageGameStateHandler _onMessageGameState;
    private event OnMessageAttackedHandler _onMessageAttacked;
    private event OnMessageDespawnObjectHandler _onMessageDespawnObject;
    private event OnMessageSpawnNodesHandler _onMessageSpawnNodes;
    private event OnMessageNPCMovedHandler _onMessageNPCMoved;
    private event OnMessageSpawnNPCsHandler _onMessageSpawnNPCs;
    private event OnMessageInventoryAddHandler _onMessageInventoryAdd;
    private event OnMessageInventoryRemoveHandler _onMessageInventoryRemove;
    private event OnMessageCraftedHandler _onMessageCrafted;
    private event OnMessageHealthChangedHandler _onMessageHealthChanged;
    private event OnMessageChannelHandler _onMessageChannel;
    private event OnMessageCastHandler _onMessageCast;
    private event OnMessageStopActivityHandler _onMessageStopActivity;
    private event OnMessageExperienceChangedHandler _onMessageExperienceChanged;

    public event OnMessageJoinedGameHandler OnMessageJoinedGameEvent {
        add => _onMessageJoinedGame += value;
        remove => _onMessageJoinedGame -= value;
    }

    public event OnMessagePlayerMovedHandler OnMessagePlayerMovedEvent {
        add => _onMessagePlayerMoved += value;
        remove => _onMessagePlayerMoved -= value;
    }

    public event OnMessageLeftGameHandler OnMessageLeftGameEvent {
        add => _onMessageLeftGame += value;
        remove => _onMessageLeftGame -= value;
    }

    public event OnMessageGameStateHandler OnMessageGameStateEvent {
        add => _onMessageGameState += value;
        remove => _onMessageGameState -= value;
    }

    public event OnMessageAttackedHandler OnMessageAttackedEvent {
        add => _onMessageAttacked += value;
        remove => _onMessageAttacked -= value;
    }

    public event OnMessageDespawnObjectHandler OnMessageDespawnObjectEvent {
        add => _onMessageDespawnObject += value;
        remove => _onMessageDespawnObject -= value;
    }

    public event OnMessageSpawnNodesHandler OnMessageSpawnNodesEvent {
        add => _onMessageSpawnNodes += value;
        remove => _onMessageSpawnNodes -= value;
    }

    public event OnMessageSpawnNPCsHandler OnMessageSpawnNPCsEvent {
        add => _onMessageSpawnNPCs += value;
        remove => _onMessageSpawnNPCs -= value;
    }

    public event OnMessageNPCMovedHandler OnMessageNPCMovedEvent {
        add => _onMessageNPCMoved += value;
        remove => _onMessageNPCMoved -= value;
    }

    public event OnMessageInventoryAddHandler OnMessageInventoryAddEvent {
        add => _onMessageInventoryAdd += value;
        remove => _onMessageInventoryAdd -= value;
    }

    public event OnMessageInventoryRemoveHandler OnMessageInventoryRemoveEvent {
        add => _onMessageInventoryRemove += value;
        remove => _onMessageInventoryRemove -= value;
    }

    public event OnMessageCraftedHandler OnMessageCraftedEvent {
        add => _onMessageCrafted += value;
        remove => _onMessageCrafted -= value;
    }

    public event OnMessageHealthChangedHandler OnMessageHealthChangedEvent {
        add => _onMessageHealthChanged += value;
        remove => _onMessageHealthChanged -= value;
    }

    public event OnMessageChannelHandler OnMessageChannelEvent {
        add => _onMessageChannel += value;
        remove => _onMessageChannel -= value;
    }

    public event OnMessageCastHandler OnMessageCastEvent {
        add => _onMessageCast += value;
        remove => _onMessageCast -= value;
    }

    public event OnMessageStopActivityHandler OnMessageStopActivityEvent {
        add => _onMessageStopActivity += value;
        remove => _onMessageStopActivity -= value;
    }

    public event OnMessageExperienceChangedHandler OnMessageExperienceChangedEvent {
        add => _onMessageExperienceChanged += value;
        remove => _onMessageExperienceChanged -= value;
    }

    public static MessageHandler Current => _current;

    public OnMessageJoinedGameHandler OnMessageJoinedGame => _onMessageJoinedGame;

    public OnMessagePlayerMovedHandler OnMessagePlayerMoved => _onMessagePlayerMoved;

    public OnMessageLeftGameHandler OnMessageLeftGame => _onMessageLeftGame;

    public OnMessageGameStateHandler OnMessageGameState => _onMessageGameState;

    public OnMessageAttackedHandler OnMessageAttacked => _onMessageAttacked;

    public OnMessageDespawnObjectHandler OnMessageDespawnObject => _onMessageDespawnObject;

    public OnMessageSpawnNodesHandler OnMessageSpawnNodes => _onMessageSpawnNodes;

    public OnMessageSpawnNPCsHandler OnMessageSpawnNPCs => _onMessageSpawnNPCs;

    public OnMessageNPCMovedHandler OnMessageNPCMoved => _onMessageNPCMoved;

    public OnMessageInventoryAddHandler OnMessageInventoryAdd => _onMessageInventoryAdd;

    public OnMessageInventoryRemoveHandler OnMessageInventoryRemove => _onMessageInventoryRemove;

    public OnMessageCraftedHandler OnMessageCrafted => _onMessageCrafted;

    public OnMessageHealthChangedHandler OnMessageHealthChanged => _onMessageHealthChanged;

    public OnMessageChannelHandler OnMessageChannel => _onMessageChannel;

    public OnMessageCastHandler OnMessageCast => _onMessageCast;

    public OnMessageStopActivityHandler OnMessageStopActivity => _onMessageStopActivity;

    public OnMessageExperienceChangedHandler OnMessageExperienceChanged => _onMessageExperienceChanged;
}

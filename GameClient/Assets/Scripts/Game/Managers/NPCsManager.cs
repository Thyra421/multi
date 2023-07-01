using System.Collections.Generic;
using UnityEngine;

public class NPCsManager : MonoBehaviour
{
    private static NPCsManager _current;
    private readonly List<Node> _nodes = new List<Node>();
    private event OnAddedNodeHandler _onAddedNode;
    private event OnRemovedNodeHandler _onRemovedNode;

    private Node FindNode(string id) => _nodes.Find((Node n) => n.Id == id);

    private void CreateNode(NetworkObjectData data) {
        GameObject newObject = Instantiate(Resources.Load<GameObject>($"{SharedConfig.PREFABS_PATH}/{data.prefabName}"), data.transform.position.ToVector3, Quaternion.Euler(data.transform.rotation.ToVector3));
        Node newNode = newObject.AddComponent<Node>();
        newNode.Initialize(data.id);
        _nodes.Add(newNode);
        _onAddedNode?.Invoke(newNode);
    }

    private void RemoveNode(string id) {
        Node node = FindNode(id);
        _onRemovedNode?.Invoke(node);
        _nodes.Remove(node);
        Destroy(node.gameObject);
    }

    private void OnMessageSpawnNodes(MessageSpawnNodes messageSpawnNodes) {
        foreach (NetworkObjectData o in messageSpawnNodes.nodes) {
            CreateNode(o);
        }
    }

    private void OnMessageDespawnObject(MessageDespawnObject messageDespawnObject) {
        RemoveNode(messageDespawnObject.id);
    }

    private void Awake() {
        if (_current == null)
            _current = this;
        else
            Destroy(gameObject);
        MessageHandler.Current.OnMessageDespawnObjectEvent += OnMessageDespawnObject;
        MessageHandler.Current.OnMessageSpawnNodesEvent += OnMessageSpawnNodes;
    }

    public delegate void OnAddedNodeHandler(Node node);
    public delegate void OnRemovedNodeHandler(Node node);

    public static NPCsManager Current => _current;

    public event OnAddedNodeHandler OnAddedNodeEvent {
        add => _onAddedNode += value;
        remove => _onAddedNode -= value;
    }

    public event OnRemovedNodeHandler OnRemovedNodeEvent {
        add => _onRemovedNode += value;
        remove => _onRemovedNode -= value;
    }
}
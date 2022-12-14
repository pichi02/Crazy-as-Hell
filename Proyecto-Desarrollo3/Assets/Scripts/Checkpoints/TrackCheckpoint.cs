using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoint : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;
    public event Action OnLapFinish;

    private List<CheckpointSingle> checkpointSingleList;

    private int nextCheckpointSingleIndex;

    public int index;

    public Vector3 vectorPoint;
    public Vector3 directionPoint;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();

        foreach(Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            if (checkpointSingleList.Count - 1 == nextCheckpointSingleIndex)
            {
                Debug.Log(checkpointSingleList.Count + " " + nextCheckpointSingleIndex);
                AddGoalIndex();
                OnLapFinish?.Invoke();
            }
            Debug.Log("Correct");
            vectorPoint = checkpointSingle.transform.position;
            directionPoint = checkpointSingle.transform.forward;
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Wrong");
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
        }
    }

    private void AddGoalIndex()
    {
        index++;
    }
}

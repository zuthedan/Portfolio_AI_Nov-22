using Behaviour;

public static class CreateBehaviourTree
{
    private static AgentBehaviourStats stats;
    public static BehaviourTree CreateTree(AgentBehaviourStats stats)
    {
        
        CreateBehaviourTree.stats = stats;

        CompositeNode head = new SelectorNode();
        BehaviourTree tree = new(head);

        AddSwitchingVisibilityBehaviour(head);
        AddRageBuildingBehaviour(head);
        AddStopAndLookAtPlayerBehaviour(head);
        AddRandomMovementBehaviour(head);

        return tree;
    }

    private static void AddSwitchingVisibilityBehaviour(CompositeNode parent)
    {
        SequenceNode seq0 = new SequenceNode();
        {
            SequenceNode seq1 = new SequenceNode();
            {
                seq1.AppendChild(new TimerNode(stats.ChangeVisibilityTimer));
                seq1.AppendChild(new ChangeFloatToRandomValueNode(stats.ChangeVisibilityTimer, 3f, 5f));

            }
            seq0.AppendChild(seq1);


            // Selector
            SelectorNode sel = new SelectorNode();
            {
                AddTurningVisibleBehaviour(sel);
                AddTurningInvisibleBehaviour(sel);
            }
            seq0.AppendChild(sel);
        }
        parent.AppendChild(seq0);
    }

    private static void AddTurningVisibleBehaviour(CompositeNode parent)
    {
        // Sequence
        SequenceNode seq = new SequenceNode();
        {
            // is not Visible
            InverterNode i = new InverterNode();
            {
                i.Child = new IsVisibleNode(stats.IsVisible);
            }
            seq.AppendChild(i);

            // is not in Player vision
            seq.AppendChild(new OutOfPlayerViewNode(stats.PlayerFov, stats.PlayerTransform, stats.AgentTransform));

            // chance
            seq.AppendChild(new CalculateChanceNode(stats.TurnVisibleChance));

            // ChangeVisibility
            seq.AppendChild(new ChangeVisibilityNode(stats.AgentMeshRenderer, stats.IsVisible));
        }
        parent.AppendChild(seq);
    }

    private static void AddTurningInvisibleBehaviour(CompositeNode parent)
    {
        SequenceNode seq = new SequenceNode();
        {
            // is visible
            seq.AppendChild(new IsVisibleNode(stats.IsVisible));

            // is not in player Vision
            seq.AppendChild(new OutOfPlayerViewNode(stats.PlayerFov, stats.PlayerTransform, stats.AgentTransform));

            // chance
            seq.AppendChild(new CalculateChanceNode(stats.TurnVisibleChance));

            // change visibility
            seq.AppendChild(new ChangeVisibilityNode(stats.AgentMeshRenderer, stats.IsVisible));
        }
        parent.AppendChild(seq);
    }
    

    private static void AddRageBuildingBehaviour(CompositeNode parent)
    {
        FailNode f = new FailNode();
        {
            UninterruptedSelectorNode u = new UninterruptedSelectorNode();
            {
                u.AppendChild(new IncreaseRageByDistance(stats.AgentTransform,stats.PlayerTransform,stats.SearchRadius,stats.Rage,stats.RageDistanceScaleFactor));
                u.AppendChild(new IncreaseRageByLookingNode(stats.PlayerTransform,stats.AgentTransform,stats.LookAtAngle,stats.Rage));
            }
            f.Child = u;
        }
        parent.AppendChild(f);
    }

    private static void AddStopAndLookAtPlayerBehaviour(CompositeNode parent)
    {
        SequenceNode seq = new SequenceNode();
        {
            SelectorNode sel = new SelectorNode();
            {
                // checkPlayerNearby
                sel.AppendChild(new PlayerInRangeNode(stats.SearchRadius, stats.AgentTransform, stats.PlayerTransform));

                InverterNode i = new InverterNode();
                {
                    i.Child = new OutOfPlayerViewNode(stats.PlayerFov, stats.PlayerTransform, stats.AgentTransform);
                }
                sel.AppendChild(i);
            }

            // Look at player
            seq.AppendChild(new LookAtPlayerNode(stats.AgentTransform,stats.PlayerTransform));
        }
        parent.AppendChild(seq);

    }

    private static void AddRandomMovementBehaviour(CompositeNode parent)
    {
        CompositeNode sequence = new SequenceNode();
        {
            sequence.AppendChild(new TimerNode(stats.MovementStopTime));
            sequence.AppendChild(new ChangeDirectionRandomNode(stats.AgentTransform,stats.MovementStopTime));
        }
        parent.AppendChild(sequence);

        parent.AppendChild(new WalkAroundNode(stats.AgentRigidbody,stats.AgentSpeed));
    }
}

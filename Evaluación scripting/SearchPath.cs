using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluación_scripting
{
    class Node
    {
        public bool isExplored = false;
        public Node isExploredFrom;
        public int X { set; get; }
        public int Y { set; get; }
        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
        
    }
    struct Vector
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class SearchPath
    {
        private Node _startingPoint;
        private Node _endingPoint;
        private Dictionary<Vector, Node> _block = new Dictionary<Vector, Node>();
        private Vector[] _directions = { new Vector(0, 1), new Vector(1, 0), new Vector(0, -1), new Vector(-1, 0) };
        private Queue<Node> _queue = new Queue<Node>();
        private Node _searchingPoint;
        private bool _isExploring = true;

        private List<Node> _path = new List<Node>();
        public void create()
        {
            Node[] arraynode = { new Node(0, 0), new Node(0, 1), new Node(0, 2),
         new Node(0, 3),
         new Node(1, 0),
         new Node(1, 1),
         new Node(1, 2),
         new Node(1, 3),
         new Node(2, 0),
         new Node(2, 1),
         new Node(2, 2),
         new Node(2, 3),
         new Node(3, 0),
         new Node(3, 1),
         new Node(3, 2),
         new Node(3, 3)
        };

            Vector[] arrayvector =
             {
                new Vector(0, 0),
                new Vector(0, 1),
                new Vector(0, 2),
                new Vector(0, 3),
                new Vector(1, 0),
                new Vector(1, 1),
                new Vector(1, 2),
                new Vector(1, 3),
                new Vector(2, 0),
                new Vector(2, 1),
                new Vector(2, 2),
                new Vector(2, 3),
                new Vector(3, 0),
                new Vector(3, 1),
                new Vector(3, 2),
                new Vector(3, 3)


        };

            for (int i = 0; i < arraynode.Length; i++)
            {
                if (arrayvector[i].X == 0 && arrayvector[i].Y == 0)
                {
                    _startingPoint = arraynode[i];
                    _block.Add(arrayvector[i], _startingPoint);
                }
                else if (arrayvector[i].X == 3 && arrayvector[i].Y == 3)
                {
                    _endingPoint = arraynode[i];
                    _block.Add(arrayvector[i], _endingPoint);
                }
               else  _block.Add(arrayvector[i], arraynode[i]);
                
            }


        }
        public void BFS()
        {
            _queue.Enqueue(_startingPoint);
            while (_queue.Count > 0 && _isExploring)
            {
                _searchingPoint = _queue.Dequeue();
                OnReachingEnd();
                ExploreNeighbourNodes();
            }
        }
        private void OnReachingEnd()
        {
            if (_searchingPoint == _endingPoint)
            {
                _isExploring = false;
            }
            else
            {
                _isExploring = true;
            }
        }
        private void ExploreNeighbourNodes()
        {
            if (!_isExploring) { return; }

            foreach (Vector direction in _directions)
            {
                Vector neighbourPos = (new Vector(direction.X + _searchingPoint.X, direction.Y + _searchingPoint.Y));

                if (_block.ContainsKey(neighbourPos))               // If the explore neighbour is present in the dictionary _block, which contians all the blocks with Node.cs attached
                {
                    Node node = _block[neighbourPos];

                    if (!node.isExplored)
                    {
                        _queue.Enqueue(node);                       // Enqueueing the node at this position
                        node.isExplored = true;
                       
                        node.isExploredFrom = _searchingPoint;      // Set how we reached the neighbouring node i.e the previous node; for getting the path
                    }
                }
            }
        }
        public void CreatePath()
        {
            SetPath(_endingPoint);
            Node previousNode = _endingPoint.isExploredFrom;

            while (previousNode != _startingPoint)
            {
                SetPath(previousNode);
                previousNode = previousNode.isExploredFrom;
            }

            SetPath(_startingPoint);
            _path.Reverse();
            

        }
        private void SetPath(Node node)
        {
            _path.Add(node);
        }
        public void solution()
        {
            for(int i = 0; i < _path.Count; i++)
            {
                Console.WriteLine(_path[i].X + "-" + _path[i].Y);
            }
        }
    }

   
}

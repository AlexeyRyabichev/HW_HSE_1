using System;
using System.Collections.Generic;

namespace MyLib
{
    public class Graph
    {
        private readonly List<Vertex> _vertices = new List<Vertex>();
        private int[][] _weightAdjacencyMatrix;

        public int[][] WeightAdjacencyMatrix
        {
            get
            {
                BuildWeightAdjacencyMatrix();
                return _weightAdjacencyMatrix;
            }
        }

        public Vertex this[int index] => _vertices[index];

        public void AddVertex(Vertex vertex)
        {
            _vertices.Add(vertex);
        }

        private void BuildWeightAdjacencyMatrix()
        {
            _weightAdjacencyMatrix = new int[_vertices.Count][];
            for (int i = 0; i < _weightAdjacencyMatrix.Length; i++)
            {
                _weightAdjacencyMatrix[i] = new int[_vertices.Count];

                for (int j = 0; j < _weightAdjacencyMatrix[i].Length; j++)
                    // dij = |xi - xj| + |yi - yj|
                    _weightAdjacencyMatrix[i][j] = Math.Abs(_vertices[i].X - _vertices[j].X) +
                                                   Math.Abs(_vertices[i].Y - _vertices[j].Y);
            }
        }
    }
}
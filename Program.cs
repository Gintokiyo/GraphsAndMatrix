using System;
using System.Collections.Generic;

namespace TestCSharp
{
    class Program
    {
        static void Main()
        {
            var firstMatrix = new Matrix(sizeMatrix: 4, typeOfMatrix: "neoriented");
            var secondMatrix = new Matrix(sizeMatrix: 4, typeOfMatrix: "oriented");

            firstMatrix.AddArc();
            firstMatrix.ShowMatrix();

            secondMatrix.AddArc(1, 2);
            secondMatrix.AddArc(2, 4);
            secondMatrix.ShowMatrix();
        }
    }

    //Adjacency Matrix
    public class Matrix
    {
        private readonly List<List<int>> _newMatrix;
        private readonly int _sizeMatrix;
        private readonly string _typeOfMatrix;

        public Matrix(int sizeMatrix, string typeOfMatrix)
        {
            _newMatrix = new List<List<int>>(_sizeMatrix);
            _sizeMatrix = sizeMatrix;
            _typeOfMatrix = typeOfMatrix;

            //Construct the matrix with 0s
            for (int rowMat = 0; rowMat < _sizeMatrix; rowMat++)
            {
                _newMatrix.Add(AddRow());
            }
        }

        public List<int> AddRow()
        {
            var newRow = new List<int>(_sizeMatrix);
            for (int i = 0; i < _sizeMatrix; i++)
            {
                newRow.Add(0);
            }

            return newRow;
        }

        public void AddArc(int arcBegin, int arcEnd)
        {
            _newMatrix[arcBegin - 1][arcEnd - 1] = 1;
            if (_typeOfMatrix == "neoriented" || _typeOfMatrix == "undirected")
                _newMatrix[arcEnd - 1][arcBegin - 1] = 1;
        }

        public void AddArc()
        {
            char confirm;
            int arcBegin;
            int arcEnd;
            do
            {
                Console.Write("Insert a new arc which begins from point: ");
                arcBegin = Convert.ToInt32(Console.ReadLine());
                arcBegin = arcBegin <= _sizeMatrix ? arcBegin : _sizeMatrix;

                Console.Write("And ends at point: ");
                arcEnd = Convert.ToInt32(Console.ReadLine());
                arcEnd = arcEnd <= _sizeMatrix ? arcEnd : _sizeMatrix;

                _newMatrix[arcBegin - 1][arcEnd - 1] = 1;
                if (_typeOfMatrix == "neoriented" || _typeOfMatrix == "undirected")
                    _newMatrix[arcEnd - 1][arcBegin - 1] = 1;

                Console.Write("Do you want to insert another arc? [y/n]");
                confirm = Convert.ToChar(Console.ReadLine());

            } while (confirm != 'n' && confirm != 'N');
        }

        public void DeleteArc(int arcBegin, int arcEnd)
        {
            _newMatrix[arcBegin - 1][arcEnd - 1] = 0;
            if (_typeOfMatrix == "neoriented" || _typeOfMatrix == "undirected")
                _newMatrix[arcEnd - 1][arcBegin - 1] = 0;
        }

        public void ShowMatrix()
        {
            for (int rowMat = 0; rowMat < _sizeMatrix; rowMat++)
            {
                for (int colMat = 0; colMat < _sizeMatrix; colMat++)
                {
                    Console.Write($"{_newMatrix[rowMat][colMat]} ");
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }
    }
}

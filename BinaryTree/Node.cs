
/*
     The contents of this file are subject to the Mozilla Public License
     Version 1.1 (the "License"); you may not use this file except in
     compliance with the License. You may obtain a copy of the License at
     http://www.mozilla.org/MPL/

     Software distributed under the License is distributed on an "AS IS"
     basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
     License for the specific language governing rights and limitations
     under the License.

     The Original Code is OpenMCDF - Compound Document Format library.

     The Initial Developer of the Original Code is Federico Blaseotto.
 
     The code is modified to more now a days standards and upgraded to
     C# .NET 4.0 by Kees van Spelde
*/

namespace CompoundFileStorage.BinaryTree
{
    /// <summary>
    ///     The Node&lt;T&gt; class represents the base concept of a Node for a tree or graph.  It contains
    ///     a data item of type T, and a list of neighbors.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the Node.</typeparam>
    /// <remarks>
    ///     None of the classes in the SkmDataStructures2 namespace use the Node class directly;
    ///     they all derive from this class, adding necessary functionality specific to each data structure.
    /// </remarks>
    public class Node<T>
    {
        #region Properties
        public T Value { get; set; }

        protected NodeList<T> Neighbors { get; set; }
        #endregion

        #region Constructors
        public Node()
        {
            Neighbors = null;
        }

        public Node(T data) : this(data, null)
        {
        }

        public Node(T data, NodeList<T> neighbors)
        {
            Value = data;
            Neighbors = neighbors;
        }
        #endregion
    }
}
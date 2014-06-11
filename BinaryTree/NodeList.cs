using System.Collections.ObjectModel;

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
    ///     Represents a collection of Node&lt;T&gt; instances.
    /// </summary>
    /// <typeparam name="T">The type of data held in the Node instances referenced by this class.</typeparam>
    public class NodeList<T> : Collection<Node<T>>
    {
        #region Constructors
        public NodeList()
        {
        }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (var i = 0; i < initialSize; i++)
                Items.Add(default(Node<T>));
        }
        #endregion

        #region FindByValue
        /// <summary>
        ///     Searches the NodeList for a Node containing a particular value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The Node in the NodeList, if it exists; null otherwise.</returns>
        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (var node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
        #endregion
    }
}
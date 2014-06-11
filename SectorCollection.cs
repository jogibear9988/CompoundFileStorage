using System;
using System.Collections;
using System.Collections.Generic;

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

namespace CompoundFileStorage
{
    /// <summary>
    ///     Ad-hoc Heap Friendly sector collection to avoid using large array that may create some problem to GC collection
    ///     (see http://www.simple-talk.com/dotnet/.net-framework/the-dangers-of-the-large-object-heap/ )
    /// </summary>
    internal class SectorCollection : IList<Sector>
    {
        #region Fields
        private const int SliceSize = 4096;
        private readonly List<ArrayList> _largeArraySlices = new List<ArrayList>();
        #endregion

        #region IList<T> Members
        public int IndexOf(Sector item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Sector item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Sector this[int index]
        {
            get
            {
                var itemIndex = index/SliceSize;
                var itemOffset = index%SliceSize;

                if ((index > -1) && (index < Count))
                    return (Sector) _largeArraySlices[itemIndex][itemOffset];

                throw new ArgumentOutOfRangeException("index", index, "Argument out of range");
            }

            set
            {
                var itemIndex = index/SliceSize;
                var itemOffset = index%SliceSize;

                if (index > -1 && index < Count)
                {
                    _largeArraySlices[itemIndex][itemOffset] = value;
                }
                else
                    throw new ArgumentOutOfRangeException("index", index, "Argument out of range");
            }
        }
        #endregion

        #region ICollection<T> Members
        public void Add(Sector item)
        {
            var itemIndex = Count/SliceSize;

            if (itemIndex < _largeArraySlices.Count)
            {
                _largeArraySlices[itemIndex].Add(item);
                Count++;
            }
            else
            {
                var ar = new ArrayList(SliceSize) {item};
                _largeArraySlices.Add(ar);
                Count++;
            }
        }

        public void Clear()
        {
            foreach (var slice in _largeArraySlices)
            {
                slice.Clear();
            }

            _largeArraySlices.Clear();

            Count = 0;
        }

        public bool Contains(Sector item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Sector[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Sector item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IEnumerable<T> Members
        public IEnumerator<Sector> GetEnumerator()
        {
            foreach (var largeArraySlice in _largeArraySlices)
            {
                foreach (var t in largeArraySlice)
                    yield return (Sector) t;
            }
        }
        #endregion

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var largeArraySlice in _largeArraySlices)
            {
                for (var j = 0; j < largeArraySlice.Count; j++)
                    yield return largeArraySlice[j];
            }
        }
        #endregion
    }
}
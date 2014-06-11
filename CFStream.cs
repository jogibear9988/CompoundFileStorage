using System;
using CompoundFileStorage.Exceptions;
using CompoundFileStorage.Interfaces;

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
    ///     OLE structured storage
    ///     <see cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFStream">stream</see>
    ///     Object
    ///     It is contained inside a Storage object in a file-directory relationship and indexed by its name.
    /// </summary>
    public class CFStream : CFItem, ICFStream
    {
        #region Constructors
        internal CFStream(CompoundFile sectorManager) : base(sectorManager)
        {
            DirEntry = new DirectoryEntry(StgType.StgStream);
            sectorManager.InsertNewDirectoryEntry(DirEntry);
        }

        internal CFStream(CompoundFile sectorManager, IDirectoryEntry dirEntry) : base(sectorManager)
        {
            if (dirEntry == null || dirEntry.SID < 0)
                throw new CFException("Attempting to add a CFStream using an unitialized directory");

            DirEntry = dirEntry;
        }
        #endregion

        #region SetData
        /// <summary>
        ///     Set the data associated with the stream object.
        /// </summary>
        /// <example>
        ///     <code>
        ///    byte[] b = new byte[]{0x0,0x1,0x2,0x3};
        ///    CompoundFile cf = new CompoundFile();
        ///    CFStream myStream = cf.RootStorage.AddStream("MyStream");
        ///    myStream.SetData(b);
        /// </code>
        /// </example>
        /// <param name="data">Data bytes to write to this stream</param>
        public void SetData(Byte[] data)
        {
            CheckDisposed();
            CompoundFile.SetData(this, data);
        }
        #endregion

        #region GetData
        /// <summary>
        ///     Get the data associated with the stream object.
        /// </summary>
        /// <example>
        ///     <code>
        ///     CompoundFile cf2 = new CompoundFile("AFileName.cfs");
        ///     CFStream st = cf2.RootStorage.GetStream("MyStream");
        ///     byte[] buffer = st.GetData();
        /// </code>
        /// </example>
        /// <returns>Array of byte containing stream data</returns>
        /// <exception cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFDisposedException">
        ///     Raised when the owner compound file has been closed.
        /// </exception>
        public Byte[] GetData()
        {
            CheckDisposed();

            return CompoundFile.GetData(this);
        }

        /// <summary>
        ///     Get <paramref name="count" /> bytes associated with the stream object, starting from
        ///     a provided <paramref name="offset" />. When method returns, count will contain the
        ///     effective count of bytes read.
        /// </summary>
        /// <example>
        ///     <code>
        /// CompoundFile cf = new CompoundFile("AFileName.cfs");
        /// CFStream st = cf.RootStorage.GetStream("MyStream");
        /// int count = 8;
        /// // The stream is supposed to have a length greater than offset + count
        /// byte[] data = st.GetData(20, ref count);  
        /// cf.Close();
        /// </code>
        /// </example>
        /// <returns>Array of byte containing stream data</returns>
        /// <exception cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFDisposedException">
        ///     Raised when the owner compound file has been closed.
        /// </exception>
        public Byte[] GetData(long offset, ref int count)
        {
            CheckDisposed();

            return CompoundFile.GetData(this, offset, ref count);
        }
        #endregion
    }
}
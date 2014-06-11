using System;

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

namespace CompoundFileStorage.Interfaces
{
    /// <summary>
    ///     The Stream interface
    /// </summary>
    public interface ICFStream : ICFItem
    {
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
        Byte[] GetData();

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
        Byte[] GetData(long offset, ref int count);
    }
}
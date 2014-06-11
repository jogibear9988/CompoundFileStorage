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

namespace CompoundFileStorage.Interfaces
{
    /// <summary>
    ///     The CompoundFile interface
    /// </summary>
    public interface ICompoundFile
    {
        /// <summary>
        ///     Return true if this compound file has been loaded from an existing file or stream
        /// </summary>
        bool HasSourceStream { get; }

        /// <summary>
        ///     The entry point object that represents the
        ///     root of the structures tree to get stream data.
        /// </summary>
        ICFStorage RootStorage { get; }

        CFSVersion Version { get; }

        /// <summary>
        ///     Close the Compound File object <see cref="T:OpenMcdf.CompoundFile">CompoundFile</see> and
        ///     free all associated resources (e.g. open file handle and allocated memory).
        ///     <remarks>
        ///         When the <see cref="T:OpenMcdf.CompoundFile.Close()">Close</see> method is called,
        ///         all the associated stream and storage objects are invalidated:
        ///         any operation invoked on them will produce a
        ///         <see cref="T:OpenMcdf.CFDisposedException">CFDisposedException</see>.
        ///     </remarks>
        /// </summary>
        void Close();

        /// <summary>
        ///     Get a list of all entries with a given name contained in the document.
        /// </summary>
        /// <param name="entryName">Name of entries to retrive</param>
        /// <returns>A list of name-matching entries</returns>
        /// <remarks>
        ///     This function is aimed to speed up entity lookup in
        ///     flat-structure files (only one or little more known entries)
        ///     without the performance penalty related to entities hierarchy constraints.
        ///     There is no implied hierarchy in the returned list.
        /// </remarks>
        IList<ICFItem> GetAllNamedEntries(string entryName);
    }
}
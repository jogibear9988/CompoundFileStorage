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
    ///     The compound file item interface
    /// </summary>
    public interface ICFItem
    {
        /// <summary>
        ///     Get entity name
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Size in bytes of the item. It has a valid value
        ///     only if entity is a stream, otherwise it is setted to zero.
        /// </summary>
        long Size { get; }

        /// <summary>
        ///     Return true if item is Storage
        /// </summary>
        /// <remarks>
        ///     This check doesn't use reflection or runtime type information
        ///     and doesn't suffer related performance penalties.
        /// </remarks>
        bool IsStorage { get; }

        /// <summary>
        ///     Return true if item is a Stream
        /// </summary>
        /// <remarks>
        ///     This check doesn't use reflection or runtime type information
        ///     and doesn't suffer related performance penalties.
        /// </remarks>
        bool IsStream { get; }

        /// <summary>
        ///     Return true if item is the Root Storage
        /// </summary>
        /// <remarks>
        ///     This check doesn't use reflection or runtime type information
        ///     and doesn't suffer related performance penalties.
        /// </remarks>
        bool IsRoot { get; }

        /// <summary>
        ///     Get/Set the Creation Date of the current item
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        ///     Get/Set the Modify Date of the current item
        /// </summary>
        DateTime ModifyDate { get; set; }

        /// <summary>
        ///     Get/Set Object class Guid for Root and Storage entries.
        /// </summary>
        Guid CLSID { get; set; }
    }
}
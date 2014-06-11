using System;
using System.IO;

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
    ///     The directory entry interface
    /// </summary>
    public interface IDirectoryEntry : IComparable
    {
        int Child { get; set; }

        byte[] CreationDate { get; set; }

        byte[] EntryName { get; }

        int LeftSibling { get; set; }

        byte[] ModifyDate { get; set; }

        string Name { get; }

        ushort NameLength { get; }

        int RightSibling { get; set; }

        int SID { get; set; }

        long Size { get; set; }

        int StartSector { get; set; }

        int StateBits { get; set; }

        StgColor StgColor { get; set; }

        StgType StgType { get; set; }

        Guid StorageCLSID { get; set; }
        string GetEntryName();
        void Read(Stream stream);
        void SetEntryName(string entryName);

        void Write(Stream stream);
    }
}
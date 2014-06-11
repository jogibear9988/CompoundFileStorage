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
    ///     The compound file storage interface
    /// </summary>
    public interface ICFStorage : ICFItem
    {
        /// <summary>
        ///     Gets a named
        ///     <see cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFStream">stream</see>
        ///     contained in the current storage if existing.
        /// </summary>
        /// <param name="streamName">Name of the stream to look for</param>
        /// <returns>A stream reference if existing</returns>
        /// <exception cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFDisposedException">
        ///     Raised
        ///     if trying to delete item from a closed compound file
        /// </exception>
        /// <exception cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFItemNotFound">
        ///     Raised if
        ///     item to delete is not found
        /// </exception>
        /// <example>
        ///     <code>
        ///  String filename = "report.xls";
        /// 
        ///  CompoundFile cf = new CompoundFile(filename);
        ///  CFStream foundStream = cf.RootStorage.GetStream("Workbook");
        /// 
        ///  byte[] temp = foundStream.GetData();
        /// 
        ///  Assert.IsNotNull(temp);
        /// 
        ///  cf.Close();
        ///  </code>
        /// </example>
        ICFStream GetStream(string streamName);

        /// <summary>
        ///     Checks whether a child stream exists in the parent.
        /// </summary>
        /// <param name="streamName">Name of the stream to look for</param>
        /// <returns>A boolean value indicating whether the child stream exists.</returns>
        /// <example>
        ///     <code>
        ///  string filename = "report.xls";
        /// 
        ///  CompoundFile cf = new CompoundFile(filename);
        ///  
        ///  bool exists = ExistsStream("Workbook");
        ///  
        ///  if exists
        ///  {
        ///      CFStream foundStream = cf.RootStorage.GetStream("Workbook");
        ///  
        ///      byte[] temp = foundStream.GetData();
        ///  }
        /// 
        ///  Assert.IsNotNull(temp);
        /// 
        ///  cf.Close();
        ///  </code>
        /// </example>
        bool ExistsStream(string streamName);

        /// <summary>
        ///     Gets a named storage contained in the current one if existing.
        /// </summary>
        /// <param name="storageName">Name of the storage to look for</param>
        /// <returns>A storage reference if existing.</returns>
        /// <exception cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFDisposedException">
        ///     Raised
        ///     if trying to delete item from a closed compound file
        /// </exception>
        /// <exception cref="T:DocumentServices.Modules.Extractors.OfficeExtractor.OLECompoundFileStorage.CFItemNotFound">
        ///     Raised if item to delete is not found
        /// </exception>
        /// <example>
        ///     <code>
        ///  
        ///  string FILENAME = "MultipleStorage2.cfs";
        ///  CompoundFile cf = new CompoundFile(FILENAME);
        /// 
        ///  CFStorage st = cf.RootStorage.GetStorage("MyStorage");
        /// 
        ///  Assert.IsNotNull(st);
        ///  cf.Close();
        ///  </code>
        /// </example>
        ICFStorage GetStorage(string storageName);

        /// <summary>
        ///     Checks if a child storage exists within the parent.
        /// </summary>
        /// <param name="storageName">Name of the storage to look for.</param>
        /// <returns>A boolean value indicating whether the child storage was found.</returns>
        /// <example>
        ///     <code>
        ///  string FILENAME = "MultipleStorage2.cfs";
        ///  CompoundFile cf = new CompoundFile(FILENAME, UpdateMode.ReadOnly, false, false);
        /// 
        ///  bool exists = cf.RootStorage.ExistsStorage("MyStorage");
        ///  
        ///  if exists
        ///  {
        ///      CFStorage st = cf.RootStorage.GetStorage("MyStorage");
        ///  }
        ///  
        ///  Assert.IsNotNull(st);
        ///  cf.Close();
        ///  </code>
        /// </example>
        bool ExistsStorage(string storageName);
    }
}
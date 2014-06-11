using System;
using System.Runtime.Serialization;

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

namespace CompoundFileStorage.Exceptions
{
    /// <summary>
    ///     Raised when a named stream or a storage object is not found in a parent storage.
    /// </summary>
    [Serializable]
    public class CFItemNotFound : CFException
    {
        protected CFItemNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CFItemNotFound() : base("Entry not found")
        {
        }

        public CFItemNotFound(string message) : base(message, null)
        {
        }

        public CFItemNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
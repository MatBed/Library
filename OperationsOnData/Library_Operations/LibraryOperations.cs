using OperationsOnData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationsOnData.Library_Operations
{
    public class LibraryOperations : ILibraryOperations
    {
        private readonly ILibraryContext LibraryDb;

        public LibraryOperations(ILibraryContext LibraryDb)
        {
            this.LibraryDb = LibraryDb;
        }
    }
}
using BusinessLayer.Interfaces;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    class BookBL:IBookBL
    {
        IBookRL BookRL;
        public BookBL(IBookRL BookRL)
        {
            this.BookRL = BookRL;
        }
    }
}

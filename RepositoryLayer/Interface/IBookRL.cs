using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IBookRL
    {
        AdminBookResponseData AddBook(int adminId, AddBooks adminbookData);
        public List<AdminBookResponseData> GetListOfBooks();
        public bool DeleteBookById(int adminId, string id);
    }
}

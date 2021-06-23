using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public string Username { get; set; }

        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages, string username)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Username = username;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App
{
	public class Expense
	{
		public int Id { get; set; }
		public string Description { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime DueDate { get; set; }
    }
}


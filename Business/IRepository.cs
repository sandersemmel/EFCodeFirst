﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
        public interface IRepository<T>
        {
            bool Add(T item);
            bool Remove(T item);
            List<T> GetAll();
            List<T> Find();
            T FindSingle(int? id);

        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocMaker.Logic
{
    public sealed class Model
    {
        private Model() { }

        private static Model _instance;

        public static Model Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Model();
                return _instance;
            }
        }


        private List<Data> _records;

        public List<Data> Records
        {
            get
            {
                return _records;
            }
            private set
            {
                _records = value;
            }
        }

        public void AddNewRow()
        {

        }

        public void UpdateRow()
        {

        }

        public void DeleteRow()
        {

        }

        public void DeleteAllRows()
        {

        }



        public void AddNewExam()
        {

        }

        public void DeleteExam()
        {

        }

        public void UpdateExam()
        {

        }
    }
}

using System;
using System.Collections.Generic;

namespace DocMaker.Logic
{
    public class Data
    {
        private string _type = null;
        public string Type
        {
            get
            {
                if (_type == null)
                    return "-";
                return _type;
            }
            set
            {
                _type = value;
            }
        }


        private string _target = null;
        public string Target
        {
            get
            {
                if (_target == null)
                    return "-";
                return _target;
            }
            set
            {
                _target = value;

            }
        }


        private string _examType = null;
        public string ExamType
        {
            get
            {
                if (_examType == null)
                    return "-";
                return _examType;
            }
            set
            {
                _examType = value;

            }
        }


        private string _examNumStart = null;
        public string ExamNum
        {
            get
            {
                if (_examNumStart == null)
                    return "0";
                return _examNumStart;
            }
            set
            {
                _examNumStart = value;

            }
        }


        private string _examNumEnd = null;
        public string ExamNumEnd
        {
            get
            {
                if (_examNumEnd == null)
                    return _examNumStart;
                return _examNumEnd;
            }
            set
            {
                _examNumEnd = value;

            }
        }


        private string _arrivalDate = null;
        public string ArrivalDate
        {
            get
            {
                if (_arrivalDate == null)
                    return "-";
                return _arrivalDate;
            }
            set
            {
                _arrivalDate = value;

            }
        }


        private string _sampleName = null;
        public string SampleName
        {
            get
            {
                if (_sampleName == null)
                    return "-";
                return _sampleName;
            }
            set
            {
                _sampleName = value;

            }
        }


        private string _examCount = null;
        public string ExamCount
        {
            get
            {
                if (_examCount == null)
                    return "0";
                return _examCount;
            }
            set
            {
                _examCount = value;

            }
        }


        private string _sampleWeight = null;
        public string SampleWeight
        {
            get
            {
                if (_sampleWeight == null)
                    return "0";
                return _sampleWeight;
            }
            set
            {
                _sampleWeight = value;

            }
        }


        private string _customerData = null;
        public string CustomerData
        {
            get
            {
                if (_customerData == null)
                    return "-";
                return _customerData;
            }
            set
            {
                _customerData = value;

            }
        }


        private string _sampleDestination = null;
        public string SampleDestination
        {
            get
            {
                if (_sampleDestination == null)
                    return "-";
                return _sampleDestination;
            }
            set
            {
                _sampleDestination = value;

            }
        }


        private string _responsiblePerson = null;
        public string ResponsiblePerson
        {
            get
            {
                if (_responsiblePerson == null)
                    return "0";
                return _responsiblePerson;
            }
            set
            {
                _responsiblePerson = value;

            }
        }


        private string _comment = null;
        public string Comment
        {
            get
            {
                if (_comment == null)
                    return "0";
                return _comment;
            }
            set
            {
                _comment = value;

            }
        }


        public List<DataPiece> Exam { get; set; } = null;
    }

    public class DataPiece
    {
        String ExamPoint = null;
        String ExamResult = null;
    }    
    

}


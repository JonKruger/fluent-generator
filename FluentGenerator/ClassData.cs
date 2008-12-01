using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class ClassData : IGeneratable
    {
        private string _className;
        private bool _withPropertyChanging;
        private bool _withPropertyChanged;
        private string _primaryKeyProperty;
        private IList<ClassPropertyData> _properties = new List<ClassPropertyData>();
        private IList<ClassListData> _lists = new List<ClassListData>();
        private string _databaseTableName;

        public string Generate()
        {
            throw new NotImplementedException();
        }

        public ClassData WithName(string className)
        {
            _className = className;
            return this;
        }

        public ClassData WithPropertyChanging()
        {
            _withPropertyChanging = true;
            return this;
        }

        public ClassData WithPropertyChanged()
        {
            _withPropertyChanged = true;
            return this;
        }

        public ClassData AddPrimaryKeyProperty(string propertyName)
        {
            _primaryKeyProperty = propertyName;
            return this;
        }

        public ClassPropertyData AddProperty(string name)
        {
            ClassPropertyData propertyData = new ClassPropertyData(this);
            _properties.Add(propertyData.WithName(name));
            return propertyData;            
        }

        public ClassListData AddListOf(string listType)
        {
            ClassListData listData = new ClassListData(this);
            _lists.Add(listData.Of(listType));
            return listData;
        }

        public ClassData FromDatabaseTable(string databaseTableName)
        {
            _databaseTableName = databaseTableName;
            return this;
        }
    }

    public class ClassPropertyData : ClassData
    {
        private ClassData _parent;
        private string _name;
        private string _type;

        public ClassPropertyData(ClassData parent)
        {
            _parent = parent;
        }

        public ClassPropertyData WithName(string name)
        {
            _name = name;
            return this;
        }

        public ClassPropertyData OfType(string type)
        {
            _type = type;
            return this;
        }
    }

    public class ClassListData: ClassData
    {
        private ClassData _parent;
        private string _objectType;
        private string _name;

        public ClassListData(ClassData parent)
        {
            _parent = parent;
        }

        public ClassListData Of(string objectType)
        {
            _objectType = objectType;
            return this;
        }

        public ClassListData WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}

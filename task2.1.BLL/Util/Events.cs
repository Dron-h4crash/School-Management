using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._1.BLL.Util
{
    public class Events
    {
        public delegate void MethodContainer(List<Changes> Operations);

        public event MethodContainer ChangesSaved;

        public void OnChangesSaved(ChangedData changedData)
        {
            ChangesSaved(changedData.Operations);
        }
    }
    public class Changes
    {
        public string Field {get; set;}
        public string OperationName { get; set; }
    }

    public abstract class ChangedData
    {

        public ChangedData(string field)
        {
            this.Operations = new List<Changes>();
            this.Field = field;
        }

        public String Field { get; set; }
        public List<Changes> Operations { get; set; }
        public abstract List<Changes> AddOperation();

        
    }

    public class PeoplesChanges : ChangedData
    {
        public PeoplesChanges() : base("Peoples")
        { }
        public override List<Changes> AddOperation()
        {
            return this.Operations;
        }
    }


    public abstract class ChangedDataDecorator : ChangedData
    {
        public ChangedData changedData;
        public ChangedDataDecorator(string n,  ChangedData changedData) : base(n)
        {
            this.changedData = changedData;
        }
    }
    

    public class AddingOperation : ChangedDataDecorator
    {
        public AddingOperation(ChangedData p)
            : base(p.Field, p)
        { }

        public override List<Changes> AddOperation()
        {
            this.Operations = changedData.AddOperation();
            this.Operations.Add(new Changes { Field = this.Field, OperationName = "ADD" });
            return this.Operations;
        }
    }

    public class DelOperation : ChangedDataDecorator
    {
        public DelOperation(ChangedData p)
            : base(p.Field, p)
        { }

        public override List<Changes> AddOperation()
        {
            this.Operations = changedData.AddOperation();
            this.Operations.Add(new Changes { Field = this.Field, OperationName = "DEL" });
            return this.Operations;
        }
    }

    public class EditOperation : ChangedDataDecorator
    {
        public EditOperation(ChangedData p)
            : base(p.Field, p)
        { }

        public override List<Changes> AddOperation()
        {
            this.Operations = changedData.AddOperation();
            this.Operations.Add(new Changes { Field = this.Field, OperationName = "EDIT" });
            return this.Operations;
        }
    }
}

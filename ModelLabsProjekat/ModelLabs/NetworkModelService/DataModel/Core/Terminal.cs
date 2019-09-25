using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        public long ConnectivityNode { get; set; }
        public long ConductingEquipment { get; set; }

        public Terminal(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal t = (Terminal)obj;
                return (t.ConnectivityNode == this.ConnectivityNode && t.ConductingEquipment == this.ConductingEquipment);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                case ModelCode.TERMINAL_CONDEQ:
                    return true;
                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    property.SetValue(ConductingEquipment);
                    break;

                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    property.SetValue(ConnectivityNode);
                    break;
                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONDEQ:
                    ConductingEquipment = property.AsReference();
                    break;
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    ConnectivityNode = property.AsReference();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (ConductingEquipment != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both)) 
            {                         
                references[ModelCode.TERMINAL_CONDEQ] = new List<long>();
                references[ModelCode.TERMINAL_CONDEQ].Add(ConductingEquipment);
            }

            if (ConnectivityNode != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {                         
                references[ModelCode.TERMINAL_CONNECTIVITYNODE] = new List<long>();
                references[ModelCode.TERMINAL_CONNECTIVITYNODE].Add(ConnectivityNode);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}

using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConnectivityNode : IdentifiedObject
    {
        public string Description { get; set; }
        public List<long> Terminals { get; set; } = new List<long>();

        public ConnectivityNode(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConnectivityNode c = (ConnectivityNode)obj;
                return (c.Description == this.Description && CompareHelper.CompareLists(c.Terminals, this.Terminals));
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
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                case ModelCode.CONNECTIVITYNODE_TERMINALS:
                    return true;
                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    property.SetValue(Description);
                    break;
                case ModelCode.CONNECTIVITYNODE_TERMINALS:
                    property.SetValue(Terminals);
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
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    Description = property.ToString();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return Terminals.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (Terminals != null && Terminals.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {                        
                references[ModelCode.CONNECTIVITYNODE_TERMINALS] = Terminals.GetRange(0, Terminals.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {       
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    Terminals.Add(globalId);
                    break;
                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {                   //KLASA KOG TIPA JE LISTA
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    if (Terminals.Contains(globalId))
                    {
                        Terminals.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }
                    break;
                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation
    }
}

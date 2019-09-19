using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PerLengthImpendance : IdentifiedObject
    {
        List<long> ACLineSegments { get; set; } = new List<long>();

        public PerLengthImpendance(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PerLengthImpendance x = (PerLengthImpendance)obj;
                return CompareHelper.CompareLists(x.ACLineSegments, this.ACLineSegments);
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

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.PERLENGTHIMP_ACLINESEGMENTS:
                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.PERLENGTHIMP_ACLINESEGMENTS:
                    prop.SetValue(ACLineSegments);
                    break;
                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            base.SetProperty(property);
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return ACLineSegments.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType) //SAMO OVA METODA ZA JEDNU
        {       
            //ZA LISTU
            //SUPROTNA KLASA
            if (ACLineSegments != null && ACLineSegments.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {                          //UNUTRASNJA_DALJAKLASA
                references[ModelCode.ACLINESEGMENT_PERLENGTHIMP] = ACLineSegments.GetRange(0, ACLineSegments.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {                       //DALJA KLASA_TRENUTNA
                case ModelCode.ACLINESEGMENT_PERLENGTHIMP:
                    ACLineSegments.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.ACLINESEGMENT_PERLENGTHIMP:

                    if (ACLineSegments.Contains(globalId))
                    {
                        ACLineSegments.Remove(globalId);
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

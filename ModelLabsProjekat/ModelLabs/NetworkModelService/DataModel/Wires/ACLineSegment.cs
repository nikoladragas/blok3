using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class ACLineSegment : Conductor
    {
        float B0ch { get; set; }
        float Bch { get; set; }
        float G0ch { get; set; }
        float Gch { get; set; }
        float R { get; set; }
        float R0 { get; set; }
        float X { get; set; }
        float X0 { get; set; }
        long PerLengthImpedance { get; set; }
        

        public ACLineSegment(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ACLineSegment x = (ACLineSegment)obj;
                return ((x.B0ch == this.B0ch) && (x.G0ch == this.G0ch) && (x.R == this.R) && (x.R0 == this.R0) && (x.X == this.X) && (x.X0 == this.X0) && (x.PerLengthImpedance == this.PerLengthImpedance));
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
                case ModelCode.ACLINESEGMENT_B0CH:
                case ModelCode.ACLINESEGMENT_BCH:
                case ModelCode.ACLINESEGMENT_G0CH:
                case ModelCode.ACLINESEGMENT_GCH:
                case ModelCode.ACLINESEGMENT_R:
                case ModelCode.ACLINESEGMENT_R0:
                case ModelCode.ACLINESEGMENT_X:
                case ModelCode.ACLINESEGMENT_X0:
                case ModelCode.ACLINESEGMENT_PERLENGTHIMP:
                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.ACLINESEGMENT_B0CH:
                    prop.SetValue(B0ch);
                    break;
                case ModelCode.ACLINESEGMENT_BCH:
                    prop.SetValue(Bch);
                    break;
                case ModelCode.ACLINESEGMENT_G0CH:
                    prop.SetValue(G0ch);
                    break;
                case ModelCode.ACLINESEGMENT_GCH:
                    prop.SetValue(Gch);
                    break;
                case ModelCode.ACLINESEGMENT_R:
                    prop.SetValue(R);
                    break;
                case ModelCode.ACLINESEGMENT_R0:
                    prop.SetValue(R0);
                    break;
                case ModelCode.ACLINESEGMENT_X:
                    prop.SetValue(X);
                    break;
                case ModelCode.ACLINESEGMENT_X0:
                    prop.SetValue(X0);
                    break;
                case ModelCode.ACLINESEGMENT_PERLENGTHIMP:
                    prop.SetValue(PerLengthImpedance);
                    break;
                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.ACLINESEGMENT_B0CH:
                    B0ch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_BCH:
                    Bch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_G0CH:
                    G0ch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_GCH:
                    Gch = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_R:
                    R = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_R0:
                    R0 = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_X:
                    X = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_X0:
                    X0 = property.AsFloat();
                    break;
                case ModelCode.ACLINESEGMENT_PERLENGTHIMP:
                    PerLengthImpedance = property.AsReference();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType) //SAMO OVA METODA ZA JEDNU
        {       
            if (PerLengthImpedance != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both)) //za jednu
            {                         
                references[ModelCode.ACLINESEGMENT_PERLENGTHIMP] = new List<long>();
                references[ModelCode.ACLINESEGMENT_PERLENGTHIMP].Add(PerLengthImpedance);
            }

            base.GetReferences(references, refType);
        }
        #endregion IReference implementation
    }
}

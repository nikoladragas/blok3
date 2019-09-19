using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PerLengthSequenceImpedance : PerLengthImpendance
    {
        float B0ch { get; set; }
        float Bch { get; set; }
        float G0ch { get; set; }
        float Gch { get; set; }
        float R { get; set; }
        float R0 { get; set; }
        float X { get; set; }
        float X0 { get; set; }
        public PerLengthSequenceImpedance(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PerLengthSequenceImpedance x = (PerLengthSequenceImpedance)obj;
                return ((x.B0ch == this.B0ch) && (x.G0ch == this.G0ch) && (x.R == this.R) && (x.R0 == this.R0) && (x.X == this.X) && (x.X0 == this.X0));
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
                case ModelCode.PERLENGTHSEQIMP_B0CH:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_BCH:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_G0CH:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_GCH:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_R:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_R0:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_X:
                    return true;
                case ModelCode.PERLENGTHSEQIMP_X0:
                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.PERLENGTHSEQIMP_B0CH:
                    prop.SetValue(B0ch);
                    break;
                case ModelCode.PERLENGTHSEQIMP_BCH:
                    prop.SetValue(Bch);
                    break;
                case ModelCode.PERLENGTHSEQIMP_G0CH:
                    prop.SetValue(G0ch);
                    break;
                case ModelCode.PERLENGTHSEQIMP_GCH:
                    prop.SetValue(Gch);
                    break;
                case ModelCode.PERLENGTHSEQIMP_R:
                    prop.SetValue(R);
                    break;
                case ModelCode.PERLENGTHSEQIMP_R0:
                    prop.SetValue(R0);
                    break;
                case ModelCode.PERLENGTHSEQIMP_X:
                    prop.SetValue(X);
                    break;
                case ModelCode.PERLENGTHSEQIMP_X0:
                    prop.SetValue(X0);
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
                case ModelCode.PERLENGTHSEQIMP_B0CH:
                    B0ch = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_BCH:
                    Bch = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_G0CH:
                    G0ch = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_GCH:
                    Gch = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_R:
                    R = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_R0:
                    R0 = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_X:
                    X = property.AsFloat();
                    break;
                case ModelCode.PERLENGTHSEQIMP_X0:
                    X0 = property.AsFloat();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
    }
}

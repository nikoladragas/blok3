using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class SeriesCompensator : ConductingEquipment
    {
        public float R { get; set; }
        public float R0 { get; set; }
        public float X { get; set; }
        public float X0 { get; set; }

        public SeriesCompensator(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SeriesCompensator s = (SeriesCompensator)obj;
                return (s.R == this.R && s.R0 == this.R0 && s.X == this.X && s.X0 == this.X0);
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
                case ModelCode.SERIESCOMP_R:
                case ModelCode.SERIESCOMP_R0:
                case ModelCode.SERIESCOMP_X:
                case ModelCode.SERIESCOMP_X0:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.SERIESCOMP_R:
                    prop.SetValue(R);
                    break;
                case ModelCode.SERIESCOMP_R0:
                    prop.SetValue(R0);
                    break;
                case ModelCode.SERIESCOMP_X:
                    prop.SetValue(X);
                    break;
                case ModelCode.SERIESCOMP_X0:
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
                case ModelCode.SERIESCOMP_R:
                    R = property.AsFloat();
                    break;
                case ModelCode.SERIESCOMP_R0:
                    R0 = property.AsFloat();
                    break;
                case ModelCode.SERIESCOMP_X:
                    X = property.AsFloat();
                    break;
                case ModelCode.SERIESCOMP_X0:
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

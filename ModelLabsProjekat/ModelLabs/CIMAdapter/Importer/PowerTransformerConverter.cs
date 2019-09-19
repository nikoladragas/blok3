namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			//if ((cimIdentifiedObject != null) && (rd != null))
			//{
			//	//if (cimIdentifiedObject.MRIDHasValue)
			//	//{
			//	//	rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
			//	//}
			//	//if (cimIdentifiedObject.NameHasValue)
			//	//{
			//	//	rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
			//	//}
			//	//if (cimIdentifiedObject.DescriptionHasValue)
			//	//{
			//	//	rd.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, cimIdentifiedObject.Description));
			//	//}
			//}
		}


		public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);

				//if (cimPowerSystemResource.CustomTypeHasValue)
				//{
				//	rd.AddProperty(new Property(ModelCode.PSR_CUSTOMTYPE, cimPowerSystemResource.CustomType));
				//}
				//if (cimPowerSystemResource.LocationHasValue)
				//{
				//	long gid = importHelper.GetMappedGID(cimPowerSystemResource.Location.ID);
				//	if (gid < 0)
				//	{
				//		report.Report.Append("WARNING: Convert ").Append(cimPowerSystemResource.GetType().ToString()).Append(" rdfID = \"").Append(cimPowerSystemResource.ID);
				//		report.Report.Append("\" - Failed to set reference to Location: rdfID \"").Append(cimPowerSystemResource.Location.ID).AppendLine(" \" is not mapped to GID!");
				//	}
				//	rd.AddProperty(new Property(ModelCode.PSR_LOCATION, gid));
				//}
			}
		}

		

		public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);
			}
		}

		public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimConductingEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);
			}
		}

        public static void PopulateSeriesCompensatorProperties(FTN.SeriesCompensator cimSeriesCompensator, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSeriesCompensator != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimSeriesCompensator, rd, importHelper, report);

                if(cimSeriesCompensator.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMP_R, cimSeriesCompensator.R));
                }
                if (cimSeriesCompensator.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMP_R0, cimSeriesCompensator.R0));
                }
                if (cimSeriesCompensator.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMP_X, cimSeriesCompensator.X));
                }
                if (cimSeriesCompensator.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMP_X0, cimSeriesCompensator.X0));
                }
            }
        }

        public static void PopulateConductorProperties(FTN.Conductor cimConductor, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if(cimConductor != null && rd != null)
            {
                PopulateConductingEquipmentProperties(cimConductor, rd, importHelper, report);

                if(cimConductor.LengthHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CONDUCTOR_LENGTH, cimConductor.Length));
                }
            }
        }

        public static void PopulateDCLineSegmentProperties(FTN.DCLineSegment cimDCLineSegment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if(cimDCLineSegment != null && rd != null)
                PopulateConductorProperties(cimDCLineSegment, rd, importHelper, report);
        }

        public static void PopulateACLineSegmentProperties(FTN.ACLineSegment cimACLineSegment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if(cimACLineSegment != null & rd != null)
            { 
                PopulateConductorProperties(cimACLineSegment, rd, importHelper, report);

                if(cimACLineSegment.B0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_B0CH, cimACLineSegment.B0ch));
                }
                if (cimACLineSegment.BchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_BCH, cimACLineSegment.Bch));
                }
                if (cimACLineSegment.G0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_G0CH, cimACLineSegment.G0ch));
                }
                if (cimACLineSegment.GchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_GCH, cimACLineSegment.Gch));
                }
                if (cimACLineSegment.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_R, cimACLineSegment.R));
                }
                if (cimACLineSegment.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_R0, cimACLineSegment.R0));
                }
                if (cimACLineSegment.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_X, cimACLineSegment.X));
                }
                if (cimACLineSegment.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_X0, cimACLineSegment.X0));
                }
                if (cimACLineSegment.PerLengthImpedanceHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimACLineSegment.PerLengthImpedance.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimACLineSegment.GetType().ToString()).Append(" rdfID = \"").Append(cimACLineSegment.ID);
                        report.Report.Append("\" - Failed to set reference to PowerTransformer: rdfID \"").Append(cimACLineSegment.PerLengthImpedance.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_PERLENGTHIMP, gid));
                }
            }
        }

        public static void PopulateConnectivityNodeProperties(FTN.ConnectivityNode cimConnectivityNode, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if(cimConnectivityNode != null && rd != null)
            {
                PopulateIdentifiedObjectProperties(cimConnectivityNode, rd);

                if(cimConnectivityNode.DescriptionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CONNECTIVITYNODE_DESCRIPTION, cimConnectivityNode.Description));
                }
            }
        }

        public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if (cimTerminal != null && rd != null)
            {
                PopulateIdentifiedObjectProperties(cimTerminal, rd);

                if(cimTerminal.ConnectivityNodeHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConnectivityNode.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to PowerTransformer: rdfID \"").Append(cimTerminal.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTIVITYNODE, gid));
                }
                if (cimTerminal.ConductingEquipmentHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to PowerTransformer: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONDEQ, gid));
                }
            }
        }

        public static void PopulatePerLengthImpedanceProperties(FTN.PerLengthImpedance cimPerLengthImpedance, ResourceDescription rd)
        {
            if(cimPerLengthImpedance != null && rd != null)
            {
                PopulateIdentifiedObjectProperties(cimPerLengthImpedance, rd);
            }
        }

        public static void PopulatePerLengthSequenceImpedanceProperties(FTN.PerLengthSequenceImpedance cimPerLengthSequenceImpedance, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if(cimPerLengthSequenceImpedance != null && rd != null)
            {
                PopulatePerLengthImpedanceProperties(cimPerLengthSequenceImpedance, rd);

                if(cimPerLengthSequenceImpedance.B0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_B0CH, cimPerLengthSequenceImpedance.B0ch));
                }
                if (cimPerLengthSequenceImpedance.BchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_BCH, cimPerLengthSequenceImpedance.Bch));
                }
                if (cimPerLengthSequenceImpedance.G0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_G0CH, cimPerLengthSequenceImpedance.G0ch));
                }
                if (cimPerLengthSequenceImpedance.GchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_GCH, cimPerLengthSequenceImpedance.Gch));
                }
                if (cimPerLengthSequenceImpedance.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_R, cimPerLengthSequenceImpedance.R));
                }
                if (cimPerLengthSequenceImpedance.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_R0, cimPerLengthSequenceImpedance.R0));
                }
                if (cimPerLengthSequenceImpedance.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_X, cimPerLengthSequenceImpedance.X));
                }
                if (cimPerLengthSequenceImpedance.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PERLENGTHSEQIMP_X0, cimPerLengthSequenceImpedance.X0));
                }
            }
        }

		#endregion Populate ResourceDescription

	}
}

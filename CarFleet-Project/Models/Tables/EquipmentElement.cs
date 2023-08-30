﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarFleet_Project.Models.Tables
{
    public class EquipmentElement
    {
        public int elementId { get; set; }

        public string elementName { get; set; } = "";

        public List<Vehicle> vehicles { get; set; } = new();
    }
}

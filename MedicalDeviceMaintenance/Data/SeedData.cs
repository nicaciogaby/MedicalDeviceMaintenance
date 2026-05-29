using MedicalDeviceMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalDeviceMaintenance.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Devices.Any())
            {
                return;
            }

            var devices = new List<Device>
            {
                new Device { Name = "Infusion Pump A", SerialNumber = "INF-1001", Model = "IP-200", Manufacturer = "MedEquip", Location = "Ward 1", PurchaseDate = new DateTime(2023, 5, 10), Status = "Active" },
                new Device { Name = "ECG Monitor B", SerialNumber = "ECG-2045", Model = "ECG-Pro", Manufacturer = "HealthTech", Location = "ICU", PurchaseDate = new DateTime(2022, 11, 20), Status = "Active" },
                new Device { Name = "Defibrillator C", SerialNumber = "DEF-7788", Model = "SafeShock X", Manufacturer = "LifeMed", Location = "Emergency Room", PurchaseDate = new DateTime(2021, 8, 15), Status = "Maintenance" },
                new Device { Name = "Ventilator D", SerialNumber = "VNT-3301", Model = "BreathPro 500", Manufacturer = "AirMed", Location = "ICU", PurchaseDate = new DateTime(2022, 3, 18), Status = "Active" },
                new Device { Name = "Patient Monitor E", SerialNumber = "PM-4412", Model = "VitalCheck 300", Manufacturer = "HealthTech", Location = "Ward 2", PurchaseDate = new DateTime(2023, 1, 7), Status = "Active" },
                new Device { Name = "Ultrasound Scanner F", SerialNumber = "ULT-5520", Model = "ScanMaster 200", Manufacturer = "MedEquip", Location = "Radiology", PurchaseDate = new DateTime(2020, 9, 25), Status = "Inactive" },
                new Device { Name = "Syringe Pump G", SerialNumber = "SYR-6630", Model = "FlowDose X1", Manufacturer = "LifeMed", Location = "Surgical Ward", PurchaseDate = new DateTime(2023, 6, 14), Status = "Active" },
                new Device { Name = "Pulse Oximeter H", SerialNumber = "POX-7741", Model = "OxyCheck 100", Manufacturer = "MedEquip", Location = "Ward 3", PurchaseDate = new DateTime(2021, 4, 30), Status = "Maintenance" },
                new Device { Name = "Blood Pressure Monitor I", SerialNumber = "BP-8852", Model = "PressurePro 400", Manufacturer = "HealthTech", Location = "Ward 1", PurchaseDate = new DateTime(2022, 7, 11), Status = "Active" },
                new Device { Name = "Surgical Laser J", SerialNumber = "LSR-9963", Model = "LaserCut 700", Manufacturer = "SurgeTech", Location = "Operating Theatre", PurchaseDate = new DateTime(2019, 12, 5), Status = "Active" },
                new Device { Name = "X-Ray Machine K", SerialNumber = "XRY-1122", Model = "ClearScan 900", Manufacturer = "ImagingPlus", Location = "Radiology", PurchaseDate = new DateTime(2018, 6, 20), Status = "Active" },
                new Device { Name = "MRI Scanner L", SerialNumber = "MRI-2233", Model = "MagnaView 3T", Manufacturer = "ImagingPlus", Location = "Radiology", PurchaseDate = new DateTime(2017, 3, 15), Status = "Maintenance" },
                new Device { Name = "CT Scanner M", SerialNumber = "CT-3344", Model = "TomoClear 128", Manufacturer = "ImagingPlus", Location = "Radiology", PurchaseDate = new DateTime(2020, 11, 8), Status = "Active" },
                new Device { Name = "Dialysis Machine N", SerialNumber = "DLY-4455", Model = "RenalPro 600", Manufacturer = "NephroMed", Location = "Nephrology Ward", PurchaseDate = new DateTime(2021, 2, 28), Status = "Active" },
                new Device { Name = "Incubator O", SerialNumber = "INC-5566", Model = "ThermoNest 200", Manufacturer = "NeoMed", Location = "Neonatal ICU", PurchaseDate = new DateTime(2022, 8, 19), Status = "Active" },
                new Device { Name = "Anaesthesia Machine P", SerialNumber = "ANS-6677", Model = "DeepBreath 800", Manufacturer = "AirMed", Location = "Operating Theatre", PurchaseDate = new DateTime(2020, 5, 3), Status = "Active" },
                new Device { Name = "Electrosurgical Unit Q", SerialNumber = "ESU-7788", Model = "CauterPro 350", Manufacturer = "SurgeTech", Location = "Operating Theatre", PurchaseDate = new DateTime(2021, 10, 14), Status = "Inactive" },
                new Device { Name = "Patient Bed Scale R", SerialNumber = "PBS-8899", Model = "WeighSafe 150", Manufacturer = "MedEquip", Location = "Ward 2", PurchaseDate = new DateTime(2023, 3, 22), Status = "Active" },
                new Device { Name = "Suction Machine S", SerialNumber = "SCT-9900", Model = "ClearAway 250", Manufacturer = "LifeMed", Location = "Emergency Room", PurchaseDate = new DateTime(2022, 9, 17), Status = "Active" },
                new Device { Name = "Cardiac Monitor T", SerialNumber = "CM-1011", Model = "HeartWatch Pro", Manufacturer = "HealthTech", Location = "Cardiology Ward", PurchaseDate = new DateTime(2021, 6, 30), Status = "Active" }
            };

            context.Devices.AddRange(devices);
            context.SaveChanges();

            var incidents = new List<Incident>
            {
                new Incident { Title = "Battery not charging", Description = "The battery does not hold charge properly.", DateReported = DateTime.Now.AddDays(-60), Severity = "High", Status = "Resolved", DeviceId = devices[0].Id },
                new Incident { Title = "Screen display failure", Description = "The monitor screen flickers during operation.", DateReported = DateTime.Now.AddDays(-55), Severity = "Medium", Status = "Resolved", DeviceId = devices[1].Id },
                new Incident { Title = "Alarm not triggering", Description = "Ventilator alarm fails to activate at threshold.", DateReported = DateTime.Now.AddDays(-50), Severity = "High", Status = "Resolved", DeviceId = devices[3].Id },
                new Incident { Title = "Sensor reading inaccurate", Description = "Pulse oximeter showing inconsistent SpO2 values.", DateReported = DateTime.Now.AddDays(-45), Severity = "Medium", Status = "In Progress", DeviceId = devices[7].Id },
                new Incident { Title = "Power failure during scan", Description = "Ultrasound scanner shuts down unexpectedly.", DateReported = DateTime.Now.AddDays(-40), Severity = "Low", Status = "Resolved", DeviceId = devices[5].Id },
                new Incident { Title = "Pressure reading error", Description = "Blood pressure readings are inconsistent with manual checks.", DateReported = DateTime.Now.AddDays(-35), Severity = "Medium", Status = "Open", DeviceId = devices[8].Id },
                new Incident { Title = "Laser intensity drop", Description = "Surgical laser output below required intensity.", DateReported = DateTime.Now.AddDays(-30), Severity = "High", Status = "In Progress", DeviceId = devices[9].Id },
                new Incident { Title = "Image quality degraded", Description = "X-ray images showing unexpected artifacts.", DateReported = DateTime.Now.AddDays(-28), Severity = "Medium", Status = "Open", DeviceId = devices[10].Id },
                new Incident { Title = "MRI noise abnormal", Description = "Unusual noise detected during MRI operation.", DateReported = DateTime.Now.AddDays(-25), Severity = "High", Status = "In Progress", DeviceId = devices[11].Id },
                new Incident { Title = "CT scanner overheating", Description = "CT scanner reaches high temperature after 30 minutes.", DateReported = DateTime.Now.AddDays(-22), Severity = "High", Status = "Open", DeviceId = devices[12].Id },
                new Incident { Title = "Dialysis flow rate error", Description = "Flow rate deviates from set parameters.", DateReported = DateTime.Now.AddDays(-20), Severity = "High", Status = "Resolved", DeviceId = devices[13].Id },
                new Incident { Title = "Incubator temperature unstable", Description = "Temperature fluctuates beyond acceptable range.", DateReported = DateTime.Now.AddDays(-18), Severity = "High", Status = "Open", DeviceId = devices[14].Id },
                new Incident { Title = "Gas supply warning", Description = "Anaesthesia machine displays low gas supply alert.", DateReported = DateTime.Now.AddDays(-15), Severity = "Medium", Status = "Resolved", DeviceId = devices[15].Id },
                new Incident { Title = "Suction pressure loss", Description = "Suction machine losing pressure during use.", DateReported = DateTime.Now.AddDays(-12), Severity = "Medium", Status = "In Progress", DeviceId = devices[18].Id },
                new Incident { Title = "Electrode contact failure", Description = "Cardiac monitor intermittently loses electrode contact.", DateReported = DateTime.Now.AddDays(-10), Severity = "High", Status = "Open", DeviceId = devices[19].Id },
                new Incident { Title = "Software crash on startup", Description = "Patient monitor freezes on boot screen.", DateReported = DateTime.Now.AddDays(-8), Severity = "Low", Status = "Resolved", DeviceId = devices[4].Id },
                new Incident { Title = "Flow rate deviation", Description = "Infusion pump delivering incorrect dosage.", DateReported = DateTime.Now.AddDays(-6), Severity = "High", Status = "Open", DeviceId = devices[6].Id },
                new Incident { Title = "Display backlight failure", Description = "ECG monitor backlight not functioning.", DateReported = DateTime.Now.AddDays(-4), Severity = "Low", Status = "Open", DeviceId = devices[1].Id },
                new Incident { Title = "Emergency stop malfunction", Description = "Defibrillator emergency stop button unresponsive.", DateReported = DateTime.Now.AddDays(-3), Severity = "High", Status = "In Progress", DeviceId = devices[2].Id },
                new Incident { Title = "Weight calibration off", Description = "Bed scale showing readings 2kg above actual weight.", DateReported = DateTime.Now.AddDays(-2), Severity = "Low", Status = "Open", DeviceId = devices[17].Id }
            };

            context.Incidents.AddRange(incidents);
            context.SaveChanges();

            var maintenanceActions = new List<MaintenanceAction>
            {
                new MaintenanceAction { ActionTaken = "Battery replaced", ActionDate = DateTime.Now.AddDays(-58), TechnicianName = "John Murphy", Notes = "New battery installed and tested successfully.", IncidentId = incidents[0].Id },
                new MaintenanceAction { ActionTaken = "Screen calibration completed", ActionDate = DateTime.Now.AddDays(-53), TechnicianName = "Sarah O'Brien", Notes = "Calibration completed according to manufacturer guidelines.", IncidentId = incidents[1].Id },
                new MaintenanceAction { ActionTaken = "Alarm module replaced", ActionDate = DateTime.Now.AddDays(-48), TechnicianName = "John Murphy", Notes = "Faulty alarm module replaced and tested.", IncidentId = incidents[2].Id },
                new MaintenanceAction { ActionTaken = "Sensor recalibrated", ActionDate = DateTime.Now.AddDays(-43), TechnicianName = "Sarah O'Brien", Notes = "Sensor recalibrated and accuracy verified.", IncidentId = incidents[3].Id },
                new MaintenanceAction { ActionTaken = "Power supply unit replaced", ActionDate = DateTime.Now.AddDays(-38), TechnicianName = "David Kelly", Notes = "PSU replaced, device tested for 24 hours with no issues.", IncidentId = incidents[4].Id },
                new MaintenanceAction { ActionTaken = "Pressure sensor replaced", ActionDate = DateTime.Now.AddDays(-33), TechnicianName = "John Murphy", Notes = "New pressure sensor fitted and validated.", IncidentId = incidents[5].Id },
                new MaintenanceAction { ActionTaken = "Laser tube serviced", ActionDate = DateTime.Now.AddDays(-28), TechnicianName = "David Kelly", Notes = "Laser tube cleaned and output recalibrated.", IncidentId = incidents[6].Id },
                new MaintenanceAction { ActionTaken = "Detector panel cleaned", ActionDate = DateTime.Now.AddDays(-26), TechnicianName = "Sarah O'Brien", Notes = "Detector panel cleaned and image quality restored.", IncidentId = incidents[7].Id },
                new MaintenanceAction { ActionTaken = "Cooling fan replaced", ActionDate = DateTime.Now.AddDays(-20), TechnicianName = "David Kelly", Notes = "Cooling fan replaced, temperature now stable.", IncidentId = incidents[9].Id },
                new MaintenanceAction { ActionTaken = "Flow valve replaced", ActionDate = DateTime.Now.AddDays(-18), TechnicianName = "John Murphy", Notes = "Flow valve replaced and flow rate validated.", IncidentId = incidents[10].Id },
                new MaintenanceAction { ActionTaken = "Temperature probe replaced", ActionDate = DateTime.Now.AddDays(-16), TechnicianName = "Sarah O'Brien", Notes = "New probe installed, temperature now stable.", IncidentId = incidents[11].Id },
                new MaintenanceAction { ActionTaken = "Gas cylinder replaced", ActionDate = DateTime.Now.AddDays(-14), TechnicianName = "David Kelly", Notes = "Gas supply replaced and pressure verified.", IncidentId = incidents[12].Id },
                new MaintenanceAction { ActionTaken = "Suction pump serviced", ActionDate = DateTime.Now.AddDays(-10), TechnicianName = "John Murphy", Notes = "Pump serviced and pressure restored.", IncidentId = incidents[13].Id },
                new MaintenanceAction { ActionTaken = "Software update applied", ActionDate = DateTime.Now.AddDays(-7), TechnicianName = "Sarah O'Brien", Notes = "Firmware updated, startup issue resolved.", IncidentId = incidents[15].Id },
                new MaintenanceAction { ActionTaken = "Electrode leads replaced", ActionDate = DateTime.Now.AddDays(-5), TechnicianName = "David Kelly", Notes = "All electrode leads replaced with new set.", IncidentId = incidents[14].Id },
                new MaintenanceAction { ActionTaken = "Dosage pump calibrated", ActionDate = DateTime.Now.AddDays(-4), TechnicianName = "John Murphy", Notes = "Pump recalibrated to correct dosage parameters.", IncidentId = incidents[16].Id },
                new MaintenanceAction { ActionTaken = "Backlight unit replaced", ActionDate = DateTime.Now.AddDays(-3), TechnicianName = "Sarah O'Brien", Notes = "Backlight replaced, display fully operational.", IncidentId = incidents[17].Id },
                new MaintenanceAction { ActionTaken = "Emergency stop button repaired", ActionDate = DateTime.Now.AddDays(-2), TechnicianName = "David Kelly", Notes = "Button mechanism repaired and response tested.", IncidentId = incidents[18].Id },
                new MaintenanceAction { ActionTaken = "Scale recalibrated", ActionDate = DateTime.Now.AddDays(-1), TechnicianName = "John Murphy", Notes = "Scale recalibrated using certified weights.", IncidentId = incidents[19].Id },
                new MaintenanceAction { ActionTaken = "Full system inspection", ActionDate = DateTime.Now.AddDays(-15), TechnicianName = "David Kelly", Notes = "Routine inspection completed, no critical issues found.", IncidentId = incidents[8].Id }
            };

            context.MaintenanceActions.AddRange(maintenanceActions);
            context.SaveChanges();
        }
    }
}
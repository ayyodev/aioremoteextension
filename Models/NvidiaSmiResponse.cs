/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */

using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "driver_model")]
    public class Driver_model
    {
        [XmlElement(ElementName = "current_dm")]
        public string Current_dm { get; set; }
        [XmlElement(ElementName = "pending_dm")]
        public string Pending_dm { get; set; }
    }

    [XmlRoot(ElementName = "inforom_version")]
    public class Inforom_version
    {
        [XmlElement(ElementName = "img_version")]
        public string Img_version { get; set; }
        [XmlElement(ElementName = "oem_object")]
        public string Oem_object { get; set; }
        [XmlElement(ElementName = "ecc_object")]
        public string Ecc_object { get; set; }
        [XmlElement(ElementName = "pwr_object")]
        public string Pwr_object { get; set; }
    }

    [XmlRoot(ElementName = "gpu_operation_mode")]
    public class Gpu_operation_mode
    {
        [XmlElement(ElementName = "current_gom")]
        public string Current_gom { get; set; }
        [XmlElement(ElementName = "pending_gom")]
        public string Pending_gom { get; set; }
    }

    [XmlRoot(ElementName = "gpu_virtualization_mode")]
    public class Gpu_virtualization_mode
    {
        [XmlElement(ElementName = "virtualization_mode")]
        public string Virtualization_mode { get; set; }
    }

    [XmlRoot(ElementName = "pcie_gen")]
    public class Pcie_gen
    {
        [XmlElement(ElementName = "max_link_gen")]
        public string Max_link_gen { get; set; }
        [XmlElement(ElementName = "current_link_gen")]
        public string Current_link_gen { get; set; }
    }

    [XmlRoot(ElementName = "link_widths")]
    public class Link_widths
    {
        [XmlElement(ElementName = "max_link_width")]
        public string Max_link_width { get; set; }
        [XmlElement(ElementName = "current_link_width")]
        public string Current_link_width { get; set; }
    }

    [XmlRoot(ElementName = "pci_gpu_link_info")]
    public class Pci_gpu_link_info
    {
        [XmlElement(ElementName = "pcie_gen")]
        public Pcie_gen Pcie_gen { get; set; }
        [XmlElement(ElementName = "link_widths")]
        public Link_widths Link_widths { get; set; }
    }

    [XmlRoot(ElementName = "pci_bridge_chip")]
    public class Pci_bridge_chip
    {
        [XmlElement(ElementName = "bridge_chip_type")]
        public string Bridge_chip_type { get; set; }
        [XmlElement(ElementName = "bridge_chip_fw")]
        public string Bridge_chip_fw { get; set; }
    }

    [XmlRoot(ElementName = "pci")]
    public class Pci
    {
        [XmlElement(ElementName = "pci_bus")]
        public string Pci_bus { get; set; }
        [XmlElement(ElementName = "pci_device")]
        public string Pci_device { get; set; }
        [XmlElement(ElementName = "pci_domain")]
        public string Pci_domain { get; set; }
        [XmlElement(ElementName = "pci_device_id")]
        public string Pci_device_id { get; set; }
        [XmlElement(ElementName = "pci_bus_id")]
        public string Pci_bus_id { get; set; }
        [XmlElement(ElementName = "pci_sub_system_id")]
        public string Pci_sub_system_id { get; set; }
        [XmlElement(ElementName = "pci_gpu_link_info")]
        public Pci_gpu_link_info Pci_gpu_link_info { get; set; }
        [XmlElement(ElementName = "pci_bridge_chip")]
        public Pci_bridge_chip Pci_bridge_chip { get; set; }
        [XmlElement(ElementName = "replay_counter")]
        public string Replay_counter { get; set; }
        [XmlElement(ElementName = "tx_util")]
        public string Tx_util { get; set; }
        [XmlElement(ElementName = "rx_util")]
        public string Rx_util { get; set; }
    }

    [XmlRoot(ElementName = "clocks_throttle_reasons")]
    public class Clocks_throttle_reasons
    {
        [XmlElement(ElementName = "clocks_throttle_reason_gpu_idle")]
        public string Clocks_throttle_reason_gpu_idle { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_applications_clocks_setting")]
        public string Clocks_throttle_reason_applications_clocks_setting { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_sw_power_cap")]
        public string Clocks_throttle_reason_sw_power_cap { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_hw_slowdown")]
        public string Clocks_throttle_reason_hw_slowdown { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_hw_thermal_slowdown")]
        public string Clocks_throttle_reason_hw_thermal_slowdown { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_hw_power_brake_slowdown")]
        public string Clocks_throttle_reason_hw_power_brake_slowdown { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_sync_boost")]
        public string Clocks_throttle_reason_sync_boost { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reason_sw_thermal_slowdown")]
        public string Clocks_throttle_reason_sw_thermal_slowdown { get; set; }
    }

    [XmlRoot(ElementName = "fb_memory_usage")]
    public class Fb_memory_usage
    {
        [XmlElement(ElementName = "total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "used")]
        public string Used { get; set; }
        [XmlElement(ElementName = "free")]
        public string Free { get; set; }
    }

    [XmlRoot(ElementName = "bar1_memory_usage")]
    public class Bar1_memory_usage
    {
        [XmlElement(ElementName = "total")]
        public string Total { get; set; }
        [XmlElement(ElementName = "used")]
        public string Used { get; set; }
        [XmlElement(ElementName = "free")]
        public string Free { get; set; }
    }

    [XmlRoot(ElementName = "utilization")]
    public class Utilization
    {
        [XmlElement(ElementName = "gpu_util")]
        public string Gpu_util { get; set; }
        [XmlElement(ElementName = "memory_util")]
        public string Memory_util { get; set; }
        [XmlElement(ElementName = "encoder_util")]
        public string Encoder_util { get; set; }
        [XmlElement(ElementName = "decoder_util")]
        public string Decoder_util { get; set; }
    }

    [XmlRoot(ElementName = "encoder_stats")]
    public class Encoder_stats
    {
        [XmlElement(ElementName = "session_count")]
        public string Session_count { get; set; }
        [XmlElement(ElementName = "average_fps")]
        public string Average_fps { get; set; }
        [XmlElement(ElementName = "average_latency")]
        public string Average_latency { get; set; }
    }

    [XmlRoot(ElementName = "ecc_mode")]
    public class Ecc_mode
    {
        [XmlElement(ElementName = "current_ecc")]
        public string Current_ecc { get; set; }
        [XmlElement(ElementName = "pending_ecc")]
        public string Pending_ecc { get; set; }
    }

    [XmlRoot(ElementName = "single_bit")]
    public class Single_bit
    {
        [XmlElement(ElementName = "device_memory")]
        public string Device_memory { get; set; }
        [XmlElement(ElementName = "register_file")]
        public string Register_file { get; set; }
        [XmlElement(ElementName = "l1_cache")]
        public string L1_cache { get; set; }
        [XmlElement(ElementName = "l2_cache")]
        public string L2_cache { get; set; }
        [XmlElement(ElementName = "texture_memory")]
        public string Texture_memory { get; set; }
        [XmlElement(ElementName = "texture_shm")]
        public string Texture_shm { get; set; }
        [XmlElement(ElementName = "cbu")]
        public string Cbu { get; set; }
        [XmlElement(ElementName = "total")]
        public string Total { get; set; }
    }

    [XmlRoot(ElementName = "double_bit")]
    public class Double_bit
    {
        [XmlElement(ElementName = "device_memory")]
        public string Device_memory { get; set; }
        [XmlElement(ElementName = "register_file")]
        public string Register_file { get; set; }
        [XmlElement(ElementName = "l1_cache")]
        public string L1_cache { get; set; }
        [XmlElement(ElementName = "l2_cache")]
        public string L2_cache { get; set; }
        [XmlElement(ElementName = "texture_memory")]
        public string Texture_memory { get; set; }
        [XmlElement(ElementName = "texture_shm")]
        public string Texture_shm { get; set; }
        [XmlElement(ElementName = "cbu")]
        public string Cbu { get; set; }
        [XmlElement(ElementName = "total")]
        public string Total { get; set; }
    }

    [XmlRoot(ElementName = "volatile")]
    public class Volatile
    {
        [XmlElement(ElementName = "single_bit")]
        public Single_bit Single_bit { get; set; }
        [XmlElement(ElementName = "double_bit")]
        public Double_bit Double_bit { get; set; }
    }

    [XmlRoot(ElementName = "aggregate")]
    public class Aggregate
    {
        [XmlElement(ElementName = "single_bit")]
        public Single_bit Single_bit { get; set; }
        [XmlElement(ElementName = "double_bit")]
        public Double_bit Double_bit { get; set; }
    }

    [XmlRoot(ElementName = "ecc_errors")]
    public class Ecc_errors
    {
        [XmlElement(ElementName = "volatile")]
        public Volatile Volatile { get; set; }
        [XmlElement(ElementName = "aggregate")]
        public Aggregate Aggregate { get; set; }
    }

    [XmlRoot(ElementName = "multiple_single_bit_retirement")]
    public class Multiple_single_bit_retirement
    {
        [XmlElement(ElementName = "retired_count")]
        public string Retired_count { get; set; }
        [XmlElement(ElementName = "retired_page_addresses")]
        public string Retired_page_addresses { get; set; }
    }

    [XmlRoot(ElementName = "double_bit_retirement")]
    public class Double_bit_retirement
    {
        [XmlElement(ElementName = "retired_count")]
        public string Retired_count { get; set; }
        [XmlElement(ElementName = "retired_page_addresses")]
        public string Retired_page_addresses { get; set; }
    }

    [XmlRoot(ElementName = "retired_pages")]
    public class Retired_pages
    {
        [XmlElement(ElementName = "multiple_single_bit_retirement")]
        public Multiple_single_bit_retirement Multiple_single_bit_retirement { get; set; }
        [XmlElement(ElementName = "double_bit_retirement")]
        public Double_bit_retirement Double_bit_retirement { get; set; }
        [XmlElement(ElementName = "pending_retirement")]
        public string Pending_retirement { get; set; }
    }

    [XmlRoot(ElementName = "temperature")]
    public class Temperature
    {
        [XmlElement(ElementName = "gpu_temp")]
        public string Gpu_temp { get; set; }
        [XmlElement(ElementName = "gpu_temp_max_threshold")]
        public string Gpu_temp_max_threshold { get; set; }
        [XmlElement(ElementName = "gpu_temp_slow_threshold")]
        public string Gpu_temp_slow_threshold { get; set; }
        [XmlElement(ElementName = "gpu_temp_max_gpu_threshold")]
        public string Gpu_temp_max_gpu_threshold { get; set; }
        [XmlElement(ElementName = "memory_temp")]
        public string Memory_temp { get; set; }
        [XmlElement(ElementName = "gpu_temp_max_mem_threshold")]
        public string Gpu_temp_max_mem_threshold { get; set; }
    }

    [XmlRoot(ElementName = "power_readings")]
    public class Power_readings
    {
        [XmlElement(ElementName = "power_state")]
        public string Power_state { get; set; }
        [XmlElement(ElementName = "power_management")]
        public string Power_management { get; set; }
        [XmlElement(ElementName = "power_draw")]
        public string Power_draw { get; set; }
        [XmlElement(ElementName = "power_limit")]
        public string Power_limit { get; set; }
        [XmlElement(ElementName = "default_power_limit")]
        public string Default_power_limit { get; set; }
        [XmlElement(ElementName = "enforced_power_limit")]
        public string Enforced_power_limit { get; set; }
        [XmlElement(ElementName = "min_power_limit")]
        public string Min_power_limit { get; set; }
        [XmlElement(ElementName = "max_power_limit")]
        public string Max_power_limit { get; set; }
    }

    [XmlRoot(ElementName = "clocks")]
    public class Clocks
    {
        [XmlElement(ElementName = "graphics_clock")]
        public string Graphics_clock { get; set; }
        [XmlElement(ElementName = "sm_clock")]
        public string Sm_clock { get; set; }
        [XmlElement(ElementName = "mem_clock")]
        public string Mem_clock { get; set; }
        [XmlElement(ElementName = "video_clock")]
        public string Video_clock { get; set; }
    }

    [XmlRoot(ElementName = "applications_clocks")]
    public class Applications_clocks
    {
        [XmlElement(ElementName = "graphics_clock")]
        public string Graphics_clock { get; set; }
        [XmlElement(ElementName = "mem_clock")]
        public string Mem_clock { get; set; }
    }

    [XmlRoot(ElementName = "default_applications_clocks")]
    public class Default_applications_clocks
    {
        [XmlElement(ElementName = "graphics_clock")]
        public string Graphics_clock { get; set; }
        [XmlElement(ElementName = "mem_clock")]
        public string Mem_clock { get; set; }
    }

    [XmlRoot(ElementName = "max_clocks")]
    public class Max_clocks
    {
        [XmlElement(ElementName = "graphics_clock")]
        public string Graphics_clock { get; set; }
        [XmlElement(ElementName = "sm_clock")]
        public string Sm_clock { get; set; }
        [XmlElement(ElementName = "mem_clock")]
        public string Mem_clock { get; set; }
        [XmlElement(ElementName = "video_clock")]
        public string Video_clock { get; set; }
    }

    [XmlRoot(ElementName = "max_customer_boost_clocks")]
    public class Max_customer_boost_clocks
    {
        [XmlElement(ElementName = "graphics_clock")]
        public string Graphics_clock { get; set; }
    }

    [XmlRoot(ElementName = "clock_policy")]
    public class Clock_policy
    {
        [XmlElement(ElementName = "auto_boost")]
        public string Auto_boost { get; set; }
        [XmlElement(ElementName = "auto_boost_default")]
        public string Auto_boost_default { get; set; }
    }

    [XmlRoot(ElementName = "process_info")]
    public class Process_info
    {
        [XmlElement(ElementName = "pid")]
        public string Pid { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "process_name")]
        public string Process_name { get; set; }
        [XmlElement(ElementName = "used_memory")]
        public string Used_memory { get; set; }
    }

    [XmlRoot(ElementName = "processes")]
    public class Processes
    {
        [XmlElement(ElementName = "process_info")]
        public Process_info Process_info { get; set; }
    }

    [XmlRoot(ElementName = "gpu")]
    public class Gpu
    {
        [XmlElement(ElementName = "product_name")]
        public string Product_name { get; set; }
        [XmlElement(ElementName = "product_brand")]
        public string Product_brand { get; set; }
        [XmlElement(ElementName = "display_mode")]
        public string Display_mode { get; set; }
        [XmlElement(ElementName = "display_active")]
        public string Display_active { get; set; }
        [XmlElement(ElementName = "persistence_mode")]
        public string Persistence_mode { get; set; }
        [XmlElement(ElementName = "accounting_mode")]
        public string Accounting_mode { get; set; }
        [XmlElement(ElementName = "accounting_mode_buffer_size")]
        public string Accounting_mode_buffer_size { get; set; }
        [XmlElement(ElementName = "driver_model")]
        public Driver_model Driver_model { get; set; }
        [XmlElement(ElementName = "serial")]
        public string Serial { get; set; }
        [XmlElement(ElementName = "uuid")]
        public string Uuid { get; set; }
        [XmlElement(ElementName = "minor_number")]
        public string Minor_number { get; set; }
        [XmlElement(ElementName = "vbios_version")]
        public string Vbios_version { get; set; }
        [XmlElement(ElementName = "multigpu_board")]
        public string Multigpu_board { get; set; }
        [XmlElement(ElementName = "board_id")]
        public string Board_id { get; set; }
        [XmlElement(ElementName = "gpu_part_number")]
        public string Gpu_part_number { get; set; }
        [XmlElement(ElementName = "inforom_version")]
        public Inforom_version Inforom_version { get; set; }
        [XmlElement(ElementName = "gpu_operation_mode")]
        public Gpu_operation_mode Gpu_operation_mode { get; set; }
        [XmlElement(ElementName = "gpu_virtualization_mode")]
        public Gpu_virtualization_mode Gpu_virtualization_mode { get; set; }
        [XmlElement(ElementName = "pci")]
        public Pci Pci { get; set; }
        [XmlElement(ElementName = "fan_speed")]
        public string Fan_speed { get; set; }
        [XmlElement(ElementName = "performance_state")]
        public string Performance_state { get; set; }
        [XmlElement(ElementName = "clocks_throttle_reasons")]
        public Clocks_throttle_reasons Clocks_throttle_reasons { get; set; }
        [XmlElement(ElementName = "fb_memory_usage")]
        public Fb_memory_usage Fb_memory_usage { get; set; }
        [XmlElement(ElementName = "bar1_memory_usage")]
        public Bar1_memory_usage Bar1_memory_usage { get; set; }
        [XmlElement(ElementName = "compute_mode")]
        public string Compute_mode { get; set; }
        [XmlElement(ElementName = "utilization")]
        public Utilization Utilization { get; set; }
        [XmlElement(ElementName = "encoder_stats")]
        public Encoder_stats Encoder_stats { get; set; }
        [XmlElement(ElementName = "ecc_mode")]
        public Ecc_mode Ecc_mode { get; set; }
        [XmlElement(ElementName = "ecc_errors")]
        public Ecc_errors Ecc_errors { get; set; }
        [XmlElement(ElementName = "retired_pages")]
        public Retired_pages Retired_pages { get; set; }
        [XmlElement(ElementName = "temperature")]
        public Temperature Temperature { get; set; }
        [XmlElement(ElementName = "power_readings")]
        public Power_readings Power_readings { get; set; }
        [XmlElement(ElementName = "clocks")]
        public Clocks Clocks { get; set; }
        [XmlElement(ElementName = "applications_clocks")]
        public Applications_clocks Applications_clocks { get; set; }
        [XmlElement(ElementName = "default_applications_clocks")]
        public Default_applications_clocks Default_applications_clocks { get; set; }
        [XmlElement(ElementName = "max_clocks")]
        public Max_clocks Max_clocks { get; set; }
        [XmlElement(ElementName = "max_customer_boost_clocks")]
        public Max_customer_boost_clocks Max_customer_boost_clocks { get; set; }
        [XmlElement(ElementName = "clock_policy")]
        public Clock_policy Clock_policy { get; set; }
        [XmlElement(ElementName = "supported_clocks")]
        public string Supported_clocks { get; set; }
        [XmlElement(ElementName = "processes")]
        public Processes Processes { get; set; }
        [XmlElement(ElementName = "accounted_processes")]
        public string Accounted_processes { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "nvidia_smi_log")]
    public class Nvidia_smi_log
    {
        [XmlElement(ElementName = "timestamp")]
        public string Timestamp { get; set; }
        [XmlElement(ElementName = "driver_version")]
        public string Driver_version { get; set; }
        [XmlElement(ElementName = "attached_gpus")]
        public string Attached_gpus { get; set; }
        [XmlElement(ElementName = "gpu")]
        public List<Gpu> Gpu { get; set; }
    }

}

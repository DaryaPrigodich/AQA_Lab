using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Database.Models;

public record Milestone
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? Description { get; set; }
    [JsonPropertyName("start_on"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public long? StartOn { get; set; }
    [JsonPropertyName("started_on"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public long? StartedOn { get; set; }
    [JsonPropertyName("is_started"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsStarted { get; set; }
    [JsonPropertyName("due_on"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public long? DueOn { get; set; }
    [JsonPropertyName("is_completed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public bool? IsCompleted { get; set; }
    [JsonPropertyName("completed_on"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public string? CompletedOn { get; set; }
    [JsonPropertyName("project_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ProjectId { get; set; }
    [JsonPropertyName("parent_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public int? ParentId { get; set; }
    [JsonPropertyName("refs"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Refs { get; set; }
    [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
    [JsonPropertyName("milestones"), NotMapped, JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Milestone> Milestones { get; set; } = new();
}


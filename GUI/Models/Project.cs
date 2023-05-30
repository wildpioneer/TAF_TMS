using System.Text.Json.Serialization;

namespace GUI.Models
{
    public class Project
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; init; } = string.Empty;
        [JsonPropertyName("announcement")] public string Announcement { get; init; } = string.Empty;

        [JsonPropertyName("show_announcement")]
        public bool ShowAnnouncement { get; set; }

        [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
        [JsonPropertyName("completed_on")] public string CompletedOn { get; set; }
        [JsonPropertyName("suite_mode")] public int SuiteMode { get; set; }
        [JsonPropertyName("default_role_id")] public string DefaultRoleId { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("users")] public List<User> Users { get; set; }
        [JsonPropertyName("groups")] public List<Group> Groups { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Announcement)}: {Announcement}, {nameof(ShowAnnouncement)}: " +
                $"{ShowAnnouncement}, {nameof(IsCompleted)}: {IsCompleted}, {nameof(CompletedOn)}: {CompletedOn}, {nameof(SuiteMode)}: " +
                $"{SuiteMode}, {nameof(DefaultRoleId)}: {DefaultRoleId}, {nameof(Url)}: {Url}, {nameof(Users)}: {Users}, {nameof(Groups)}: {Groups}";
        }
    }
}
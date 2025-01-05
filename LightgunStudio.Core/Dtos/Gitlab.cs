namespace LightgunStudio.Core.Dtos.Gitlab
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Assets
    {
        public int count { get; set; }
        public List<Source> sources { get; set; }
        public List<Link> links { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public bool locked { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
    }

    public class Commit
    {
        public string id { get; set; }
        public string short_id { get; set; }
        public DateTime created_at { get; set; }
        public List<string> parent_ids { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string author_name { get; set; }
        public string author_email { get; set; }
        public DateTime authored_date { get; set; }
        public string committer_name { get; set; }
        public string committer_email { get; set; }
        public DateTime committed_date { get; set; }
        public Trailers trailers { get; set; }
        public ExtendedTrailers extended_trailers { get; set; }
        public string web_url { get; set; }
    }

    public class Evidence
    {
        public string sha { get; set; }
        public string filepath { get; set; }
        public DateTime collected_at { get; set; }
    }

    public class ExtendedTrailers
    {
    }

    public class IssueStats
    {
        public int total { get; set; }
        public int closed { get; set; }
    }

    public class Link
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string direct_asset_url { get; set; }
        public string link_type { get; set; }
    }

    public class Links
    {
        public string closed_issues_url { get; set; }
        public string closed_merge_requests_url { get; set; }
        public string merged_merge_requests_url { get; set; }
        public string opened_issues_url { get; set; }
        public string opened_merge_requests_url { get; set; }
        public string self { get; set; }
    }

    public class Milestone
    {
        public int id { get; set; }
        public int iid { get; set; }
        public int project_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object due_date { get; set; }
        public object start_date { get; set; }
        public bool expired { get; set; }
        public string web_url { get; set; }
        public IssueStats issue_stats { get; set; }
    }

    public class Root
    {
        public string name { get; set; }
        public string tag_name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime released_at { get; set; }
        public bool upcoming_release { get; set; }
        public Author author { get; set; }
        public Commit commit { get; set; }
        public List<Milestone> milestones { get; set; }
        public string commit_path { get; set; }
        public string tag_path { get; set; }
        public Assets assets { get; set; }
        public List<Evidence> evidences { get; set; }
        public Links _links { get; set; }
    }

    public class Source
    {
        public string format { get; set; }
        public string url { get; set; }
    }

    public class Trailers
    {
    }

}

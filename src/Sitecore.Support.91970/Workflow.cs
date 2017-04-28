namespace Sitecore.Support.Shell.Feeds.FeedTypes
{
    using System;
    using System.Collections.Generic;
    using Data.Items;
    using System.Linq;
    using System.ServiceModel.Syndication;
    using System.Web;
    using Workflows;

    public class Workflow : Sitecore.Shell.Feeds.FeedTypes.Workflow
    {
        public Workflow(Item feedItem) : base(feedItem)
        {
        }

        protected override IList<SyndicationItem> GetSyndicationItems()
        {
            // Exclude all null items from the syndication items list.
            return base.GetSyndicationItems().Where(x => x != null).ToList();
        }

        protected override SyndicationItem BuildSyndicationItem(Item item, WorkflowEvent workflowEvent)
        {
            // Do not build syndication items for items without a workflow.
            if (item.State.GetWorkflow() == null)
            {
                return null;
            }

            return base.BuildSyndicationItem(item, workflowEvent);
        }
    }
}
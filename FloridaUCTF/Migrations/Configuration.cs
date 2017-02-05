namespace FloridaUCTF.Migrations
{
	using Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<FloridaUCTF.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(FloridaUCTF.Models.ApplicationDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			context.States.AddOrUpdate(x => x.StateCode,
				new State() { StateCode = "AL", StateName = "Alabama" },
				new State() { StateCode = "AK", StateName = "Alaska" },
				new State() { StateCode = "AZ", StateName = "Arizona" },
				new State() { StateCode = "AR", StateName = "Arkansas" },
				new State() { StateCode = "CA", StateName = "California" },
				new State() { StateCode = "CO", StateName = "Colorado" },
				new State() { StateCode = "CT", StateName = "Connecticut" },
				new State() { StateCode = "DE", StateName = "Delaware" },
				new State() { StateCode = "DC", StateName = "District of Columbia" },
				new State() { StateCode = "FL", StateName = "Florida" },
				new State() { StateCode = "GA", StateName = "Georgia" },
				new State() { StateCode = "HI", StateName = "Hawaii" },
				new State() { StateCode = "ID", StateName = "Idaho" },
				new State() { StateCode = "IL", StateName = "Illinois" },
				new State() { StateCode = "IN", StateName = "Indiana" },
				new State() { StateCode = "IA", StateName = "Iowa" },
				new State() { StateCode = "KS", StateName = "Kansas" },
				new State() { StateCode = "KY", StateName = "Kentucky" },
				new State() { StateCode = "LA", StateName = "Louisiana" },
				new State() { StateCode = "ME", StateName = "Maine" },
				new State() { StateCode = "MD", StateName = "Maryland" },
				new State() { StateCode = "MA", StateName = "Massachusetts" },
				new State() { StateCode = "MI", StateName = "Michigan" },
				new State() { StateCode = "MN", StateName = "Minnesota" },
				new State() { StateCode = "MS", StateName = "Mississippi" },
				new State() { StateCode = "MO", StateName = "Missouri" },
				new State() { StateCode = "MT", StateName = "Montana" },
				new State() { StateCode = "NE", StateName = "Nebraska" },
				new State() { StateCode = "NV", StateName = "Nevada" },
				new State() { StateCode = "NH", StateName = "New Hampshire" },
				new State() { StateCode = "NJ", StateName = "New Jersey" },
				new State() { StateCode = "NM", StateName = "New Mexico" },
				new State() { StateCode = "NY", StateName = "New York" },
				new State() { StateCode = "NC", StateName = "North Carolina" },
				new State() { StateCode = "ND", StateName = "North Dakota" },
				new State() { StateCode = "OH", StateName = "Ohio" },
				new State() { StateCode = "OK", StateName = "Oklahoma" },
				new State() { StateCode = "OR", StateName = "Oregon" },
				new State() { StateCode = "PA", StateName = "Pennsylvania" },
				new State() { StateCode = "RI", StateName = "Rhode Island" },
				new State() { StateCode = "SC", StateName = "South Carolina" },
				new State() { StateCode = "SD", StateName = "South Dakota" },
				new State() { StateCode = "TN", StateName = "Tennessee" },
				new State() { StateCode = "TX", StateName = "Texas" },
				new State() { StateCode = "UT", StateName = "Utah" },
				new State() { StateCode = "VT", StateName = "Vermont" },
				new State() { StateCode = "VA", StateName = "Virginia" },
				new State() { StateCode = "WA", StateName = "Washington" },
				new State() { StateCode = "WV", StateName = "West Virginia" },
				new State() { StateCode = "WI", StateName = "Wisconsin" },
				new State() { StateCode = "WY", StateName = "Wyoming" });

			context.Actions.AddOrUpdate(x => x.Id,
				new Models.Action() { Id = 1, Description = "Arrest-Felony" },
				new Models.Action() { Id = 2, Description = "Arrest-Misdemeanor" },
				new Models.Action() { Id = 3, Description = "Citation" },
				new Models.Action() { Id = 4, Description = "Notice to Appear-Felony" },
				new Models.Action() { Id = 5, Description = "Notice to Appear-Misdemeanor" },
				new Models.Action() { Id = 6, Description = "Verbal Warning" },
				new Models.Action() { Id = 7, Description = "Written Warning" }
				);
			context.Rulings.AddOrUpdate(x => x.Id,
				new Ruling() { Id = 1, Description = "Dismissed" },
				new Ruling() { Id = 2, Description = "Guilty" },
				new Ruling() { Id = 3, Description = "Not Guilty" }
				);
		}
	}
}


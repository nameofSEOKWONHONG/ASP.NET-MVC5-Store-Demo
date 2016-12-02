using Store.Data.Configuration;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data {
	/// <summary>
	/// 어플리케이션이 처음으로 실행되는 경우 시드값을 주기 위해서, 다음의 클래스를 프로젝트 루트에 추가
	/// </summary>
	public class StoreEntities : DbContext {
		public StoreEntities() : base("StoreEntities") { }

		public DbSet<Gadget> Gadgets { get; set; }
		public DbSet<Category> Categories { get; set; }

		public virtual void Commit() {
			base.SaveChanges();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Configurations.Add(new GadgetConfiguration());
			modelBuilder.Configurations.Add(new CategoryConfiguration());
		}
	}
}

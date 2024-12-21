using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1.models
{
    public partial class ChatAppDBContext : DbContext
    {
        public ChatAppDBContext()
            : base("name=ChatAppDBContext")
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<GroupMember> GroupMembers { get; set; }
        public virtual DbSet<GroupMessage> GroupMessages { get; set; }
        public virtual DbSet<GroupNotification> GroupNotifications { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<ReadReceipt> ReadReceipts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMessage>()
                .HasMany(e => e.Attachments)
                .WithRequired(e => e.GroupMessage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupMessage>()
                .HasMany(e => e.ReadReceipts)
                .WithRequired(e => e.GroupMessage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupMembers)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupMessages)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupNotifications)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AddressID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.RequesterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GroupMembers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GroupMessages)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SenderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GroupNotifications)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ReadReceipts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

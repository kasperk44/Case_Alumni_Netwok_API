// <auto-generated />
using System;
using AlumniNetworkAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlumniNetworkAPI.Migrations
{
    [DbContext(typeof(AlumniNetworkDbContext))]
    [Migration("20220407144140_Migration03")]
    partial class Migration03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Event", b =>
                {
                    b.Property<int>("Event_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowGuests")
                        .HasColumnType("bit");

                    b.Property<string>("Banner_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedByUserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Event_Id");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.EventGroupInvite", b =>
                {
                    b.Property<int>("inviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("inviteId");

                    b.HasIndex("EventId");

                    b.HasIndex("GroupId");

                    b.ToTable("EventGroupInvites");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.EventTopicInvite", b =>
                {
                    b.Property<int>("EventTopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<int?>("topic_id")
                        .HasColumnType("int");

                    b.HasKey("EventTopicId");

                    b.HasIndex("EventId");

                    b.HasIndex("TopicId");

                    b.HasIndex("topic_id");

                    b.ToTable("EventTopicInvites");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Group", b =>
                {
                    b.Property<int>("group_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("isPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("group_id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.GroupUser", b =>
                {
                    b.Property<int>("GroupUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GroupUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Post", b =>
                {
                    b.Property<int>("Post_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ReplyParentId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderUserId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetTopicId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Post_Id");

                    b.HasIndex("ReplyParentId");

                    b.HasIndex("SenderUserId");

                    b.HasIndex("TargetGroupId");

                    b.HasIndex("TargetTopicId");

                    b.HasIndex("TargetUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Topic", b =>
                {
                    b.Property<int>("topic_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("topic_id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KeycloakId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bio")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("fun_fact")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("picture")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("Groupsgroup_id")
                        .HasColumnType("int");

                    b.Property<int>("UsersuserId")
                        .HasColumnType("int");

                    b.HasKey("Groupsgroup_id", "UsersuserId");

                    b.HasIndex("UsersuserId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.Property<int>("Topicstopic_id")
                        .HasColumnType("int");

                    b.Property<int>("UsersuserId")
                        .HasColumnType("int");

                    b.HasKey("Topicstopic_id", "UsersuserId");

                    b.HasIndex("UsersuserId");

                    b.ToTable("TopicUser");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Event", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.User", "CreatedByUser")
                        .WithMany("Events")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.EventGroupInvite", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.Event", "Event")
                        .WithMany("EventGroupInvites")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Domain.Group", "Group")
                        .WithMany("EventGroupInvites")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.EventTopicInvite", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.Event", "Event")
                        .WithMany("EventTopicInvites")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Domain.Group", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Domain.Topic", null)
                        .WithMany("EventTopicInvites")
                        .HasForeignKey("topic_id");

                    b.Navigation("Event");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.GroupUser", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Domain.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Post", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.Post", "ReplyParent")
                        .WithMany("Replies")
                        .HasForeignKey("ReplyParentId");

                    b.HasOne("AlumniNetworkAPI.Models.Domain.User", "SenderUser")
                        .WithMany("SenderPosts")
                        .HasForeignKey("SenderUserId");

                    b.HasOne("AlumniNetworkAPI.Models.Domain.Group", "TargetGroup")
                        .WithMany("Posts")
                        .HasForeignKey("TargetGroupId");

                    b.HasOne("AlumniNetworkAPI.Models.Domain.Topic", "TargetTopic")
                        .WithMany("Posts")
                        .HasForeignKey("TargetTopicId");

                    b.HasOne("AlumniNetworkAPI.Models.Domain.User", "TargetUser")
                        .WithMany("TargetPosts")
                        .HasForeignKey("TargetUserId");

                    b.Navigation("ReplyParent");

                    b.Navigation("SenderUser");

                    b.Navigation("TargetGroup");

                    b.Navigation("TargetTopic");

                    b.Navigation("TargetUser");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.Group", null)
                        .WithMany()
                        .HasForeignKey("Groupsgroup_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Domain.Topic", null)
                        .WithMany()
                        .HasForeignKey("Topicstopic_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Event", b =>
                {
                    b.Navigation("EventGroupInvites");

                    b.Navigation("EventTopicInvites");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Group", b =>
                {
                    b.Navigation("EventGroupInvites");

                    b.Navigation("GroupUsers");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Post", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.Topic", b =>
                {
                    b.Navigation("EventTopicInvites");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Domain.User", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("GroupUsers");

                    b.Navigation("SenderPosts");

                    b.Navigation("TargetPosts");
                });
#pragma warning restore 612, 618
        }
    }
}

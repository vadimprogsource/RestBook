USE [restbook]
GO
/****** Object:  Table  [rbs_addresses]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_addresses](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[last_access_time] [datetime2](7) NOT NULL,
	[Country] [nvarchar](max) NULL,
	[zip] [nvarchar](20) NULL,
	[region] [nvarchar](100) NULL,
	[city] [nvarchar](100) NULL,
	[street] [nvarchar](100) NULL,
	[house] [nvarchar](10) NULL,
	[build] [nvarchar](10) NULL,
	[floor] [nvarchar](10) NULL,
	[flat] [nvarchar](10) NULL,
	[hash_code] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_rbs_addresses] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table  [rbs_catalogs]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_catalogs](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
 CONSTRAINT [PK_rbs_catalogs] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_catalogs_access]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_catalogs_access](
	[access_index] [int] NOT NULL,
	[access_location_guid] [uniqueidentifier] NOT NULL,
	[access_catalog_guid] [uniqueidentifier] NOT NULL,
	[access_weekend_flag] [bit] NOT NULL,
	[access_workday_flag] [bit] NOT NULL,
	[access_holiday_flag] [bit] NOT NULL,
	[access_start_time] [bigint] NOT NULL,
	[access_to_time] [bigint] NOT NULL,
 CONSTRAINT [PK_rbs_catalogs_access] PRIMARY KEY CLUSTERED 
(
	[access_location_guid] ASC,
	[access_catalog_guid] ASC,
	[access_index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_groups]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_groups](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
	[cat_guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_rbs_groups] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_locations]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_locations](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
	[location_org_guid] [uniqueidentifier] NOT NULL,
	[location_img_info] [nvarchar](255) NULL,
	[location_work_from] [time](7) NOT NULL,
	[location_work_to] [time](7) NOT NULL,
	[location_cook_descr] [nvarchar](max) NULL,
	[location_interier_info] [nvarchar](255) NULL,
	[location_palces_info] [nvarchar](255) NULL,
	[location_act_descr] [nvarchar](max) NULL,
	[location_ev_descr] [nvarchar](max) NULL,
 CONSTRAINT [PK_rbs_locations] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table  [rbs_orderitems]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_orderitems](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[location_guid] [uniqueidentifier] NULL,
	[product_guid] [uniqueidentifier] NOT NULL,
	[order_guid] [uniqueidentifier] NOT NULL,
	[order_item_qty] [decimal](18, 2) NOT NULL,
	[order_item_price] [decimal](18, 2) NOT NULL,
	[order_item_discount] [decimal](18, 2) NOT NULL,
	[order_item_total] [decimal](18, 2) NOT NULL,
	[order_item_tax] [decimal](18, 2) NOT NULL,
	[order_item_place] [nvarchar](20) NULL,
 CONSTRAINT [PK_rbs_orderitems] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_orders]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_orders](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
	[order_org_guid] [uniqueidentifier] NOT NULL,
	[order_customer_guid] [uniqueidentifier] NOT NULL,
	[order_address_guid] [uniqueidentifier] NULL,
	[order_number] [nvarchar](30) NULL,
	[order_date] [datetime2](7) NOT NULL,
	[order_discount] [decimal](18, 2) NOT NULL,
	[order_sub_total] [decimal](18, 2) NOT NULL,
	[order_total_tax] [decimal](18, 2) NOT NULL,
	[order_total_due] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_rbs_orders] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_orgs]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_orgs](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
	[contact_cellular] [nvarchar](100) NULL,
	[contact_phone] [nvarchar](100) NULL,
	[contact_email] [nvarchar](100) NULL,
	[contact_skype] [nvarchar](100) NULL,
	[org_address_guid] [uniqueidentifier] NOT NULL,
	[org_rating] [int] NOT NULL,
 CONSTRAINT [PK_rbs_orgs] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_products]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_products](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
	[product_cat_guid] [uniqueidentifier] NOT NULL,
	[product_group_guid] [uniqueidentifier] NOT NULL,
	[product_list_price] [decimal](18, 2) NOT NULL,
	[product_net_cost] [decimal](18, 2) NOT NULL,
	[product_unit_weight] [decimal](18, 2) NOT NULL,
	[product_unit_energy] [decimal](18, 2) NOT NULL,
	[product_unit_code] [nvarchar](max) NULL,
	[product_unit_volume] [decimal](18, 2) NOT NULL,
	[product_weights_descr] [nvarchar](2000) NULL,
 CONSTRAINT [PK_rbs_products] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table  [rbs_sessions]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_sessions](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[session_created_dt] [datetime2](7) NOT NULL,
	[session_expired_dt] [datetime2](7) NOT NULL,
	[session_pin_guid] [uniqueidentifier] NOT NULL,
	[session_pin_hash] [varbinary](32) NULL,
	[session_user_guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_rbs_sessions] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table  [rbs_users]    Script Date: 1/3/2020 1:43:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [rbs_users](
	[obj_guid] [uniqueidentifier] NOT NULL,
	[obj_reord_lev] [int] NOT NULL,
	[entity_name] [nvarchar](500) NULL,
	[entity_code] [nvarchar](50) NULL,
	[entity_uri] [nvarchar](250) NULL,
	[entity_descr] [nvarchar](2000) NULL,
	[contact_cellular] [nvarchar](100) NULL,
	[contact_phone] [nvarchar](100) NULL,
	[contact_email] [nvarchar](100) NULL,
	[contact_skype] [nvarchar](100) NULL,
	[user_created_dt] [datetime2](7) NOT NULL,
	[user_access_role] [tinyint] NOT NULL,
	[user_login_name] [nvarchar](50) NULL,
	[user_address_guid] [uniqueidentifier] NULL,
	[user_password_guid] [uniqueidentifier] NOT NULL,
	[user_password_hash] [varbinary](32) NULL,
 CONSTRAINT [PK_rbs_users] PRIMARY KEY CLUSTERED 
(
	[obj_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE  [rbs_catalogs_access]  WITH CHECK ADD  CONSTRAINT [FK_rbs_catalogs_access_rbs_catalogs_access_catalog_guid] FOREIGN KEY([access_catalog_guid])
REFERENCES  [rbs_catalogs] ([obj_guid])
GO
ALTER TABLE  [rbs_catalogs_access] CHECK CONSTRAINT [FK_rbs_catalogs_access_rbs_catalogs_access_catalog_guid]
GO
ALTER TABLE  [rbs_catalogs_access]  WITH CHECK ADD  CONSTRAINT [FK_rbs_catalogs_access_rbs_locations_access_location_guid] FOREIGN KEY([access_location_guid])
REFERENCES  [rbs_locations] ([obj_guid])
GO
ALTER TABLE  [rbs_catalogs_access] CHECK CONSTRAINT [FK_rbs_catalogs_access_rbs_locations_access_location_guid]
GO
ALTER TABLE  [rbs_groups]  WITH CHECK ADD  CONSTRAINT [FK_rbs_groups_rbs_catalogs_cat_guid] FOREIGN KEY([cat_guid])
REFERENCES  [rbs_catalogs] ([obj_guid])
GO
ALTER TABLE  [rbs_groups] CHECK CONSTRAINT [FK_rbs_groups_rbs_catalogs_cat_guid]
GO
ALTER TABLE  [rbs_locations]  WITH CHECK ADD  CONSTRAINT [FK_rbs_locations_rbs_orgs_location_org_guid] FOREIGN KEY([location_org_guid])
REFERENCES  [rbs_orgs] ([obj_guid])
GO
ALTER TABLE  [rbs_locations] CHECK CONSTRAINT [FK_rbs_locations_rbs_orgs_location_org_guid]
GO
ALTER TABLE  [rbs_orderitems]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orderitems_rbs_locations_location_guid] FOREIGN KEY([location_guid])
REFERENCES  [rbs_locations] ([obj_guid])
GO
ALTER TABLE  [rbs_orderitems] CHECK CONSTRAINT [FK_rbs_orderitems_rbs_locations_location_guid]
GO
ALTER TABLE  [rbs_orderitems]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orderitems_rbs_orders_order_guid] FOREIGN KEY([order_guid])
REFERENCES  [rbs_orders] ([obj_guid])
GO
ALTER TABLE  [rbs_orderitems] CHECK CONSTRAINT [FK_rbs_orderitems_rbs_orders_order_guid]
GO
ALTER TABLE  [rbs_orderitems]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orderitems_rbs_products_product_guid] FOREIGN KEY([product_guid])
REFERENCES  [rbs_products] ([obj_guid])
GO
ALTER TABLE  [rbs_orderitems] CHECK CONSTRAINT [FK_rbs_orderitems_rbs_products_product_guid]
GO
ALTER TABLE  [rbs_orders]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orders_rbs_addresses_order_address_guid] FOREIGN KEY([order_address_guid])
REFERENCES  [rbs_addresses] ([obj_guid])
GO
ALTER TABLE  [rbs_orders] CHECK CONSTRAINT [FK_rbs_orders_rbs_addresses_order_address_guid]
GO
ALTER TABLE  [rbs_orders]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orders_rbs_orgs_order_org_guid] FOREIGN KEY([order_org_guid])
REFERENCES  [rbs_orgs] ([obj_guid])
GO
ALTER TABLE  [rbs_orders] CHECK CONSTRAINT [FK_rbs_orders_rbs_orgs_order_org_guid]
GO
ALTER TABLE  [rbs_orders]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orders_rbs_users_order_customer_guid] FOREIGN KEY([order_customer_guid])
REFERENCES  [rbs_users] ([obj_guid])
GO
ALTER TABLE  [rbs_orders] CHECK CONSTRAINT [FK_rbs_orders_rbs_users_order_customer_guid]
GO
ALTER TABLE  [rbs_orgs]  WITH CHECK ADD  CONSTRAINT [FK_rbs_orgs_rbs_addresses_org_address_guid] FOREIGN KEY([org_address_guid])
REFERENCES  [rbs_addresses] ([obj_guid])
GO
ALTER TABLE  [rbs_orgs] CHECK CONSTRAINT [FK_rbs_orgs_rbs_addresses_org_address_guid]
GO
ALTER TABLE  [rbs_products]  WITH CHECK ADD  CONSTRAINT [FK_rbs_products_rbs_catalogs_product_cat_guid] FOREIGN KEY([product_cat_guid])
REFERENCES  [rbs_catalogs] ([obj_guid])
GO
ALTER TABLE  [rbs_products] CHECK CONSTRAINT [FK_rbs_products_rbs_catalogs_product_cat_guid]
GO
ALTER TABLE  [rbs_products]  WITH CHECK ADD  CONSTRAINT [FK_rbs_products_rbs_groups_product_group_guid] FOREIGN KEY([product_group_guid])
REFERENCES  [rbs_groups] ([obj_guid])
GO
ALTER TABLE  [rbs_products] CHECK CONSTRAINT [FK_rbs_products_rbs_groups_product_group_guid]
GO
ALTER TABLE  [rbs_sessions]  WITH CHECK ADD  CONSTRAINT [FK_rbs_sessions_rbs_users_session_user_guid] FOREIGN KEY([session_user_guid])
REFERENCES  [rbs_users] ([obj_guid])
GO
ALTER TABLE  [rbs_sessions] CHECK CONSTRAINT [FK_rbs_sessions_rbs_users_session_user_guid]
GO
ALTER TABLE  [rbs_users]  WITH CHECK ADD  CONSTRAINT [FK_rbs_users_rbs_addresses_user_address_guid] FOREIGN KEY([user_address_guid])
REFERENCES  [rbs_addresses] ([obj_guid])
GO
ALTER TABLE  [rbs_users] CHECK CONSTRAINT [FK_rbs_users_rbs_addresses_user_address_guid]
GO

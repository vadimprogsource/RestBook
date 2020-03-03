using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBook.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBook.Data.ORM
{
    public sealed class DataProductMapper : DataEntityMapper<DataProduct>
    {
        public override void Map(EntityTypeBuilder<DataProduct> context)
        {
            base.Map(context);

            context.Property(x => x.UnitCode  ).HasColumnName("product_unit_code");
            context.Property(x => x.ListPrice ).HasColumnName("product_list_price");
            context.Property(x => x.NetCost   ).HasColumnName("product_net_cost");
            context.Property(x => x.UnitWeight).HasColumnName("product_unit_weight");
            context.Property(x => x.UnitVolume).HasColumnName("product_unit_volume");

            context.Property(x => x.UnitEnergy).HasColumnName("product_unit_energy");

            context.Property(x => x.CatalogGuid).HasColumnName("product_cat_guid");
            context.Property(x => x.GroupGuid  ).HasColumnName("product_group_guid");

            context.Property(x => x.Weights).HasColumnName("product_weights_descr").HasMaxLength(2000);


            context.HasOne(x => x.Catalog).WithMany().HasForeignKey(x => x.CatalogGuid);
            context.HasOne(x => x.Group  ).WithMany(x=>x.Products).HasForeignKey(x => x.GroupGuid  );

        }



        public override void Seed(EntityTypeBuilder<DataProduct> context)
        {

            List<DataProduct> dataProducts = new List<DataProduct>();


            dataProducts.Add(new DataProduct { Name = "SALAD WITH OCTOPUS, ARGENTINIAN MUSSELS, NORWEGIAN SHRIMP AND SICILIAN SAUCE ", ListPrice = (decimal)15.98, UnitWeight = 220, Description = "", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "CAESAR WITH SHRIMPS, BACON AND POACHED EGG ", ListPrice = (decimal)13.98, UnitWeight = 220, Description = "Juicy lettuce leaves with Caesar with prawns, croutons, cherry tomatoes and Grano Padano cheese", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SALAD WITH ROAST BEEF ", ListPrice = (decimal)12.98, UnitWeight = 220, Description = "Juicy lettuce leaves, spicy roast beef  with honey sauce, cherry tomatoes, fried tomatoes", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "WITH TURKEY BEEF ", ListPrice = (decimal)12.98, UnitWeight = 220, Description = "Turkey fillet, juicy lettuce leaves in honey sauce, cucumber, orange, fried tomatoes", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SALAD WITH PARMS HAM AND PEAR ", ListPrice = (decimal)12.98, UnitWeight = 220, Description = "", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SALAD WITH BEEF TONGUE IN HONEY-MUSTARD SAUCE ", ListPrice = (decimal)11.98, UnitWeight = 220, Description = "", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "THAI WITH CHICKEN AND PRAWNS ", ListPrice = (decimal)11.98, UnitWeight = 220, Description = "Juicy lettuce leaves in spicy sauce with zucchini, grilled chicken, tiger prawns in panko and sesame", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "CAESAR WITH CHICKEN, BACON AND POACHED EGG ", ListPrice = (decimal)9.98, UnitWeight = 220, Description = "Juicy lettuce leaves with Caesar sauce with grilled chicken, croutons, cherry tomatoes and Grano Padano cheese", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "ITALIAN WITH PEAR AND WALNUT ", ListPrice = (decimal)8.98, UnitWeight = 220, Description = "Juicy lettuce leaves with grilled pear, walnut, Gorgonzola cheese, honey sauce and olive oil", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "GREEK SALAD ", ListPrice = (decimal)8.98, UnitWeight = 220, Description = "Juicy lettuce leaves, tomatoes, sweet pepper, black and green olives with unripe feta cheese and pesto", GroupGuid = DataGroupMapper.SALADS.Guid, CatalogGuid = DataGroupMapper.SALADS.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "SALMON CARPACCIO ", ListPrice = (decimal)15.98, UnitWeight = 150, Description = "Refined Italian appetizer of fresh salmon, complemented by arugula, dried tomatoes and aromatic vorchester", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SALMON TARTARE ", ListPrice = (decimal)16.98, UnitWeight = 190, Description = "Delicate salmon fillet in combination with capers, dried tomatoes and citrus dressing", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "TERRINE OF POULTRY LIVER, WITH WILD BERRIES, CRUNCHY BREAD AND BUTTER ", ListPrice = (decimal)9.98, UnitWeight = 300, Description = "", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BEEF TARTARE ", ListPrice = (decimal)14.98, UnitWeight = 280, Description = "Chopped beef filet, vorchester sauce, capers, olives, quail egg, toasts", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "CARPACCIO DI MANZO ", ListPrice = (decimal)12.98, UnitWeight = 180, Description = "Amazing beef carpaccio, cooked according to the classic Italian recipe", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "MEAT DELICACIES SET ", ListPrice = (decimal)13.98, UnitWeight = 130, Description = "Prosciutto serano, jerked carbonate, Turkish basturma, ah-oli sauce", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BALTIC HERRING WITH BACKED POTATOES ", ListPrice = (decimal)7.98, UnitWeight = 300, Description = "Baltic herring’s back, potatoes, yalta onion", GroupGuid = DataGroupMapper.COLD_SNACKS.Guid, CatalogGuid = DataGroupMapper.COLD_SNACKS.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "BEEF TONGUE TEMPURA WITH GRANA PADANO CHEESE AND TARTAR SAUCE ", ListPrice = (decimal)11.98, UnitWeight = 250, Description = "", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "DRANIKI WITH WHITE MUSHROOMS AND SOUR CREAM ", ListPrice = (decimal)6.98, UnitWeight = 260, Description = "Potato draniki with stewed in sour cream white mushrooms and champignons", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "DRANIKI WITH SALMON ", ListPrice = (decimal)10.98, UnitWeight = 260, Description = "Potato draniki with Blue cheese sauce, spicy salmon filet. Served with sour cream", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "JULIENNE WITH CHICKEN FILLET AND WHITE MUSHROOMS ", ListPrice = (decimal)7.98, UnitWeight = 145, Description = "", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "GARLIC TOASTS WITH CHEDDAR CHEESE AND BLUE-CHEESE SAUCE ", ListPrice = (decimal)4.98, UnitWeight = 235, Description = "", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BUFFALO CHICKEN WINGS MARINATED IN BBQ SAUCE, WITH CELERY AND BLUE-CHEESE SAUCE ", ListPrice = (decimal)10.98, UnitWeight = 320, Description = "", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "CHEESE CROQUETTES WITH BLUE-CHEESE SAUCE ", ListPrice = (decimal)9.98, UnitWeight = 185, Description = "", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BRUSCHETTA WITH ROAST BEEF ", ListPrice = (decimal)7.98, UnitWeight = 150, Description = "Baked beef meet, with spicy capers, fried tomatoes with warm cheese Grano Padana toasts", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BRUSCHETTA WITH CHEESE ", ListPrice = (decimal)6.98, UnitWeight = 125, Description = "Mozzarella cheese, cherry tomatoes with warm cheese Grano Padana toasts", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BRUSCHETTA WITH BAKED VEGETABLES ", ListPrice = (decimal)6.98, UnitWeight = 150, Description = "Baked eggplant, zucchini, onion, with spicy capers, fried tomatoes with warm cheese Grano Padana toasts", GroupGuid = DataGroupMapper.HOT_APPETIZERS.Guid, CatalogGuid = DataGroupMapper.HOT_APPETIZERS.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "BULBA BURGER WITH BACON AND SOUR CREAM ", ListPrice = (decimal)10.98, UnitWeight = 510, Description = "", GroupGuid = DataGroupMapper.BURGERS.Guid, CatalogGuid = DataGroupMapper.BURGERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BROOKLYN BURGER ", ListPrice = (decimal)15.98, UnitWeight = 530, Description = "Sesame bun, chef beef and pork cutlet, BBQ meet, Cheddar cheese, tomatoes, marinated cucumbers, yalta onion, iceberg lettuce", GroupGuid = DataGroupMapper.BURGERS.Guid, CatalogGuid = DataGroupMapper.BURGERS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "KOKO BURGER ", ListPrice = (decimal)13.98, UnitWeight = 530, Description = "Sesame bun, chef chicken cutlet, BBQ meet, Cheddar cheese, tomatoes, marinated cucumbers, yalta onion, iceberg lettuce", GroupGuid = DataGroupMapper.BURGERS.Guid, CatalogGuid = DataGroupMapper.BURGERS.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "MUSHROOM CREAM-SOUP ", ListPrice = (decimal)6.98, UnitWeight = 270, Description = "Pureed in cream white mushrooms. Served with truffle butter", GroupGuid = DataGroupMapper.SOUPS.Guid, CatalogGuid = DataGroupMapper.SOUPS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SALTWORT ", ListPrice = (decimal)6.98, UnitWeight = 385, Description = "Delicious meat solyanka prepared according to the original recipe", GroupGuid = DataGroupMapper.SOUPS.Guid, CatalogGuid = DataGroupMapper.SOUPS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BEETROOT SOUP ON KEFIR WITH BAKED POTATOES ", ListPrice = (decimal)4.98, UnitWeight = 405, Description = "", GroupGuid = DataGroupMapper.SOUPS.Guid, CatalogGuid = DataGroupMapper.SOUPS.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "CHICKEN KEBAB WITH BAKED POTATO AND TARTAR SAUCE ", ListPrice = (decimal)9.98, UnitWeight = 300, Description = "", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "TURKEY KEBAB ", ListPrice = (decimal)11.98, UnitWeight = 300, Description = "Juicy kebab from tender turkey fillet with potato wedges and tartar sauce", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "CHICKEN FILLET IN BACON WITH GRANO PADANA CHEESE ", ListPrice = (decimal)15.98, UnitWeight = 300, Description = "", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SOFT GRILLED TURKEY WITH SAUCE JACK DANIEL'S ", ListPrice = (decimal)13.98, UnitWeight = 150, Description = "", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "DOZENS OF SNAILS ", ListPrice = (decimal)26.98, UnitWeight = 180, Description = "Grapewine snails with spicy oil, pesto and ah-oli sauce", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SHRIMPS ON THE GRILL, WITH GARLIC SAUCE AND SPARAGE ", ListPrice = (decimal)15.98, UnitWeight = 135, Description = "", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "KACHUKA WITH SEAFOOD IN WINE-TOMATO SAUCE ", ListPrice = (decimal)14.98, UnitWeight = 350, Description = "", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SCALLOPS GRILLED WITH SALSA ALL'AGLIO SAUCE ", ListPrice = (decimal)26.98, UnitWeight =105, Weights="105/30/16", Description = "", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "FOIE GRAS ", ListPrice = (decimal)19.98, UnitWeight=120, Weights = "120/85/20", Description = "Delicate French delicacy of duck liver with berry sauce, caramelized pineapple and fruit", GroupGuid = DataGroupMapper.POULTRY_DISHES.Guid, CatalogGuid = DataGroupMapper.POULTRY_DISHES.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "RAVIOLI WITH GENTLE MEAT AND GRANA PADANO CHEESE ", ListPrice = (decimal)11.98, UnitWeight = 300, Description = "", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "RISOTTO PRIMAVERA ", ListPrice = (decimal)14.98, UnitWeight = 350, Description = "Tender beef with rice and vegetables, combined with Djugas cheese and cream", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "RISOTTO WITH WHITE MUSHROOMS ", ListPrice = (decimal)14.98, UnitWeight = 350, Description = "", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "PASTA WITH SHRIMPS AND SPARAGES, IN CREAM SAUCE ", ListPrice = (decimal)14.98, UnitWeight = 250, Description = "", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "PASTA BOLOGNESE ", ListPrice = (decimal)9.98, UnitWeight = 350, Description = "Spaghetti in cream-tomatoes sauce with stew beef in white wine and aragula", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "PASTA WITH WHITE MUSHROOMS ", ListPrice = (decimal)10.98, UnitWeight = 250, Description = "Spaghetti with white mushrooms sauce, champignons, cream and cheese Grana Padana", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "PASTA CARBONARA ", ListPrice = (decimal)10.98, UnitWeight = 250, Description = "Spaghetti with egg yolk and cream sauce, bacon and cheese Grano Padana", GroupGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.Guid, CatalogGuid = DataGroupMapper.PASTA_RAVIOLI_RISOTTO.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "WINE SET OF CHEESE ", ListPrice = (decimal)14.98, UnitWeight = 280, Description = "Set with cream feta cheese, cheese Dor Blue, cheese Brie, Dutch cheese. Served with fried hazelnut, grapes and honey", GroupGuid = DataGroupMapper.SETS.Guid, CatalogGuid = DataGroupMapper.SETS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SET FOR VODKA ", ListPrice = (decimal)15.98, UnitWeight = 400, Description = "Traditional snack set for 40◦: beef tongue with horseradish, pickles mix, lightly salted lard", GroupGuid = DataGroupMapper.SETS.Guid, CatalogGuid = DataGroupMapper.SETS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SET FOR COMPANY ", ListPrice = (decimal)24.98, UnitWeight = 620, Description = "Cheese croquettes, garlic toasts, chicken wings, grilled sausage, onion rings, Blue cheese sauce, ah-oli sauce", GroupGuid = DataGroupMapper.SETS.Guid, CatalogGuid = DataGroupMapper.SETS.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SET XXL ", ListPrice = (decimal)44.98, UnitWeight = 1150, Description = "Grilled sausages, Asian-style chicken thigh, chicken wings, cheese croquettes, Creole potato, potato pie, garlic croutons, Blue-Cheese sauce, Aioli sauce, BBQ sauce", GroupGuid = DataGroupMapper.SETS.Guid, CatalogGuid = DataGroupMapper.SETS.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "FRUIT SET ", ListPrice = (decimal)9.98, UnitWeight = 600, Description = "Apple, orange, pear, grape", GroupGuid = DataGroupMapper.DESSERT.Guid, CatalogGuid = DataGroupMapper.DESSERT.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "TIRAMISU ", ListPrice = (decimal)7.98, UnitWeight = 150, Description = "Delicate coffee cream with savoiardi cookie, grated chocolate", GroupGuid = DataGroupMapper.DESSERT.Guid, CatalogGuid = DataGroupMapper.DESSERT.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "STRUDEL WITH PEAR AND NUTS ", ListPrice = (decimal)5.98, UnitWeight = 150, Description = "", GroupGuid = DataGroupMapper.DESSERT.Guid, CatalogGuid = DataGroupMapper.DESSERT.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "PANNA COTTA ", ListPrice = (decimal)4.98, UnitWeight = 150, Description = "Cream soft desert with vanilla, berries and custard", GroupGuid = DataGroupMapper.DESSERT.Guid, CatalogGuid = DataGroupMapper.DESSERT.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "VANILLA ICE-CREAM WITH HAZELNUT AND HONEY ", ListPrice = (decimal)4.98, UnitWeight = 170, Description = "", GroupGuid = DataGroupMapper.DESSERT.Guid, CatalogGuid = DataGroupMapper.DESSERT.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "CHOCOLATE ICE-CREAM WITH APPLE AND PEAR ", ListPrice = (decimal)3.98, UnitWeight = 220, Description = "", GroupGuid = DataGroupMapper.DESSERT.Guid, CatalogGuid = DataGroupMapper.DESSERT.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "BEEF MEDALLIONS WITH ZUCCHINI ", ListPrice = (decimal)21.98, UnitWeight = 220, Description = "Veal medallions with zucchini, eggplant, paprika with sweet and sour sauce", GroupGuid = DataGroupMapper.BEEF_DISHES.Guid, CatalogGuid = DataGroupMapper.BEEF_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "PEPPER STEAK ", ListPrice = (decimal)24.98, UnitWeight = 230, Description = "Soft medium rare beef steak. Served with cream sauce", GroupGuid = DataGroupMapper.BEEF_DISHES.Guid, CatalogGuid = DataGroupMapper.BEEF_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BEEFSTEAK BROOKLYN ", ListPrice = (decimal)14.98, UnitWeight = 260, Description = "Juicy grilled beefsteak with crisp potato straws and mushroom sauce", GroupGuid = DataGroupMapper.BEEF_DISHES.Guid, CatalogGuid = DataGroupMapper.BEEF_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BEEF KEBAB WITH POTATO SLICES, LOLLO ROSSA LETTUCE AND TARTARE SAUCE ", ListPrice = (decimal)12.98, UnitWeight = 300, Description = "", GroupGuid = DataGroupMapper.BEEF_DISHES.Guid, CatalogGuid = DataGroupMapper.BEEF_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BEEF CHEEK WITH ALLA SICILIANA SAUCE ", ListPrice = (decimal)13.98, UnitWeight = 220, Description = "", GroupGuid = DataGroupMapper.BEEF_DISHES.Guid, CatalogGuid = DataGroupMapper.BEEF_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BEEF TONGUE WITH SAUCE JACK DANIEL’S WITH POTATO SLICES ", ListPrice = (decimal)13.98, UnitWeight = 200, Description = "", GroupGuid = DataGroupMapper.BEEF_DISHES.Guid, CatalogGuid = DataGroupMapper.BEEF_DISHES.CatalogGuid });

            dataProducts.Add(new DataProduct { Name = "GRILLED SIBAS ", ListPrice = (decimal)27.98, UnitWeight = 300, Description = "Grilled sibas in Mediterranean herbs with citrus notes and pesto", GroupGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.Guid, CatalogGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "GRILLED DORADO ", ListPrice = (decimal)27.98, UnitWeight = 300, Description = "Grilled whole Dorado with the addition of shambhala leaves and lemongrass. Nothing extra!", GroupGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.Guid, CatalogGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BLUEFIN TUNA WITH BAKED POTATOES AND BRAND SAUCE ", ListPrice = (decimal)17.98, UnitWeight = 200, Description = "", GroupGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.Guid, CatalogGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "SALMON GRILLED STEAK ", ListPrice = (decimal)19.98, UnitWeight = 145, Description = "", GroupGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.Guid, CatalogGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "ZANDER GRILLED STEAK WITH VEGETABLES ", ListPrice = (decimal)12.98, UnitWeight = 210, Description = "", GroupGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.Guid, CatalogGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "FISH CAKE WITH POACHED EGG AND HOLLANDA SAUCE ", ListPrice = (decimal)12.98, UnitWeight = 210, Description = "", GroupGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.Guid, CatalogGuid = DataGroupMapper.FISH_AND_SEAFOOD_DISHES.CatalogGuid });


            dataProducts.Add(new DataProduct { Name = "BAVARIAN PAN ", ListPrice = (decimal)12.98, UnitWeight = 400, Description = "Juicy Munich sausages with baked potatoes, forest mushrooms, fried onions and fragrant herbs. Served on a warm pan", GroupGuid = DataGroupMapper.PORK_DISHES.Guid, CatalogGuid = DataGroupMapper.PORK_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "GRILLED PORK NECK STEAK ", ListPrice = (decimal)13.98, UnitWeight = 230, Description = "Served with forest mushrooms sauce, fried potato straws", GroupGuid = DataGroupMapper.PORK_DISHES.Guid, CatalogGuid = DataGroupMapper.PORK_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "WIENER SCHNITZEL ", ListPrice = (decimal)11.98, UnitWeight = 355, Description = "Breaded pork neck and fried in oil to golden crust. Served with tartare sauce, lemon slice and mashed potato with cream butter", GroupGuid = DataGroupMapper.PORK_DISHES.Guid, CatalogGuid = DataGroupMapper.PORK_DISHES.CatalogGuid });
            dataProducts.Add(new DataProduct { Name = "BAKED PORK KNUCKLE ", ListPrice = (decimal)3.98, UnitWeight = 100, Description = "Pork knuckle with caramel crust and honey-mustard sauce", GroupGuid = DataGroupMapper.PORK_DISHES.Guid, CatalogGuid = DataGroupMapper.PORK_DISHES.CatalogGuid });


            int rol = 0;

            foreach (DataProduct dp in dataProducts)
            {
                dp.Guid = Guid.NewGuid();
                dp.Name = dp.Name.Trim();
                dp.Description = (dp.Description ?? string.Empty).Trim();
                dp.ReorderLevel = ++rol;
                dp.Code = string.Empty;
            }

            context.HasData(dataProducts.ToArray());
           

        }
    }


   
}

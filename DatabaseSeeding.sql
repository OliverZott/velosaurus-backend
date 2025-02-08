-- Seeding sample locations
INSERT INTO "Locations" ("Name", "Region") VALUES
('Innsbruck', 'Tirol'),
('Kufstein', 'Tirol'),
('Landeck', 'Tirol');

-- Seeding sample activities
INSERT INTO "Activities" ("Name", "Date", "Length", "AltitudeGain", "ActivityType", "Description", "LocationId") VALUES
('Mountain Biking in Innsbruck', '2024-12-30T08:00:00Z', 30, 600, 0, 'A thrilling mountain biking adventure in Innsbruck.', 1),
('Nordic Skiing in Kufstein', '2024-12-29T09:30:00Z', 20, 300, 1, 'Enjoy the nordic skiing trails near Kufstein.', 2),
('Alpine Skiing in Landeck', '2024-12-28T10:15:00Z', 10, 1200, 2, 'Ski down the alpine slopes of Landeck.', 3),
('Hiking in Innsbruck', '2024-12-27T11:45:00Z', 15, 500, 3, 'Explore the hiking trails around Innsbruck.', 1),
('Bike Tour in Kufstein', '2024-12-26T12:30:00Z', 25, 700, 0, 'A scenic bike tour through Kufstein.', 2),
('Nordic Walking in Landeck', '2024-12-25T13:00:00Z', 12, 400, 1, 'Nordic walking paths in Landeck.', 3),
('Backcountry Skiing in Innsbruck', '2024-12-24T14:00:00Z', 8, 1000, 2, 'Backcountry skiing adventures in Innsbruck.', 1),
('Mountain Hike in Kufstein', '2024-12-23T15:00:00Z', 18, 600, 3, 'A challenging mountain hike in Kufstein.', 2),
('Road Biking in Landeck', '2024-12-22T16:00:00Z', 40, 500, 0, 'Road biking through the countryside of Landeck.', 3),
('Ski Touring in Innsbruck', '2024-12-21T08:00:00Z', 10, 1100, 2, 'Ski touring routes in Innsbruck.', 1),
('Leisure Cycling in Kufstein', '2024-12-20T09:30:00Z', 22, 200, 0, 'Leisure cycling paths in Kufstein.', 2),
('Nordic Ski Tour in Landeck', '2024-12-19T10:15:00Z', 15, 700, 1, 'A nordic ski tour in Landeck.', 3),
('Forest Hike in Innsbruck', '2024-12-18T11:45:00Z', 12, 300, 3, 'A serene forest hike in Innsbruck.', 1),
('River Biking in Kufstein', '2024-12-17T12:30:00Z', 28, 400, 0, 'Biking along the river in Kufstein.', 2),
('Snowshoeing in Landeck', '2024-12-16T13:00:00Z', 8, 500, 3, 'Explore the snow-covered trails in Landeck.', 3);

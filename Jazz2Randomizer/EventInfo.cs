﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jazz2Randomizer
{
    public enum Difficulty
    {
        Any,
        Easy,
        Medium,
        Hard,
    }

    [DataContract]
    public class EventInfo
    {
        public static string[] EventNames = new string[]
        {
            null,
            "One Way",
            "Hurt",
            "Vine",
            "Hook",
            "Slide",
            "H-Pole",
            "V-Pole",
            "Area Fly Off",
            "Ricochet",
            "Belt Right",
            "Belt Left",
            "Acc Belt R",
            "Acc Belt L",
            "Stop Enemy",
            "Wind Left",
            "Wind Right",
            "Area End Of Level",
            "Area Warp EOL",
            "Area Revert Morph",
            "Area Float Up",
            "Trigger Rock",
            "Dim Light",
            "Set Light",
            "Limit X Scroll",
            "Reset Light",
            "Area Warp Secret",
            "Echo",
            "Activate Boss",
            "Jazz Level Start",
            "Spaz Level Start",
            "Multiplayer Level Start",
            "EMPTY",
            "Freezer Ammo+3",
            "Bouncer Ammo+3",
            "Seeker Ammo+3",
            "3Way Ammo+3",
            "Toaster Ammo+3",
            "TNT Ammo+3",
            "Gun8 Ammo+3",
            "Gun9 Ammo+3",
            "Still Turtleshell",
            "Swinging Vine",
            "Bomb",
            "Silver Coin",
            "Gold Coin",
            "Gun crate",
            "Carrot crate",
            "1Up crate",
            "Gem barrel",
            "Carrot barrel",
            "1up barrel",
            "Bomb Crate",
            "Freezer Ammo+15",
            "Bouncer Ammo+15",
            "Seeker Ammo+15",
            "3Way Ammo+15",
            "Toaster Ammo+15",
            "TNT (armed explosive, no pickup)",
            "Airboard",
            "Frozen Green Spring",
            "Gun Fast Fire",
            "Spring Crate",
            "Red Gem +1",
            "Green Gem +1",
            "Blue Gem +1",
            "Purple Gem +1",
            "Super Red Gem",
            "Birdy",
            "Gun Barrel",
            "Gem Crate",
            "Jazz<->Spaz",
            "Carrot Energy +1",
            "Full Energy",
            "Fire Shield",
            "Water Shield",
            "Lightning Shield",
            "Max weapon",
            "Auto fire",
            "Fast Feet",
            "Extra Live",
            "End of Level signpost",
            "EMPTY",
            "Save point signpost",
            "Bonus Level signpost",
            "Red Spring",
            "Green Spring",
            "Blue Spring",
            "Invincibility",
            "Extra Time",
            "Freeze Enemies",
            "Hor Red Spring",
            "Hor Green Spring",
            "Hor Blue Spring",
            "Morph Into Bird",
            "Scenery Trigger Crate",
            "Fly carrot",
            "RectGem Red",
            "RectGem Green",
            "RectGem Blue",
            "Tuf Turt",
            "Tuf Boss",
            "Lab Rat",
            "Dragon",
            "Lizard",
            "Bee",
            "Rapier",
            "Sparks",
            "Bat",
            "Sucker",
            "Caterpillar",
            "Cheshire1",
            "Cheshire2",
            "Hatter",
            "Bilsy Boss",
            "Skeleton",
            "Doggy Dogg",
            "Norm Turtle",
            "Helmut",
            "Leaf",
            "Demon",
            "Fire",
            "Lava",
            "Dragon Fly",
            "Monkey",
            "Fat Chick",
            "Fencer",
            "Fish",
            "Moth",
            "Steam",
            "Rotating Rock",
            "Blaster PowerUp",
            "Bouncy PowerUp",
            "Ice gun PowerUp",
            "Seek PowerUp",
            "RF PowerUp",
            "Toaster PowerUP",
            "PIN: Left Paddle",
            "PIN: Right Paddle",
            "PIN: 500 Bump",
            "PIN: Carrot Bump",
            "Apple",
            "Banana",
            "Cherry",
            "Orange",
            "Pear",
            "Pretzel",
            "Strawberry",
            "Steady Light",
            "Pulze Light",
            "Flicker Light",
            "Queen Boss",
            "Floating Sucker",
            "Bridge",
            "Lemon",
            "Lime",
            "Thing",
            "Watermelon",
            "Peach",
            "Grapes",
            "Lettuce",
            "Eggplant",
            "Cucumb",
            "Soft Drink",
            "Soda Pop",
            "Milk",
            "Pie",
            "Cake",
            "Donut",
            "Cupcake",
            "Chips",
            "Candy",
            "Chocbar",
            "Icecream",
            "Burger",
            "Pizza",
            "Fries",
            "Chicken Leg",
            "Sandwich",
            "Taco",
            "Weenie",
            "Ham",
            "Cheese",
            "Float Lizard",
            "Stand Monkey",
            "Destruct Scenery",
            "Destruct Scenery BOMB",
            "Collapsing Scenery",
            "ButtStomp Scenery",
            "Invisible GemStomp",
            "Raven",
            "Tube Turtle",
            "Gem Ring",
            "Small Tree",
            "Ambient Sound",
            "Uterus",
            "Crab",
            "Witch",
            "Rocket Turtle",
            "Bubba",
            "Devil devan boss",
            "Devan (robot boss)",
            "Robot (robot boss)",
            "Carrotus pole",
            "Psych pole",
            "Diamondus pole",
            "Sucker Tube",
            "Text",
            "Water Level",
            "Fruit Platform",
            "Boll Platform",
            "Grass Platform",
            "Pink Platform",
            "Sonic Platform",
            "Spike Platform",
            "Spike Boll",
            "Generator",
            "Eva",
            "Bubbler",
            "TNT Powerup",
            "Gun8 Powerup",
            "Gun9 Powerup",
            "Morph Frog",
            "3D Spike Boll",
            "Springcord",
            "Bees",
            "Copter",
            "Laser Shield",
            "Stopwatch",
            "Jungle Pole",
            "Warp",
            "Big Rock",
            "Big Box",
            "Water Block",
            "Trigger Scenery",
            "Bolly Boss",
            "Butterfly",
            "BeeBoy",
            "Snow",
            "EMPTY",
            "Warp Target",
            "Tweedle Boss",
            "Area Id",
            "EMPTY",
            "CTF Base + Flag",
            "No Fire Zone",
            "Trigger Zone",
            "Xmas Bilsy Boss",
            "Xmas Norm Turtle",
            "Xmas Lizard",
            "Xmas Float Lizard",
            "Addon DOG",
            "Addon Sparks",
            "EMPTY",
            "EMPTY",
            "EMPTY",
        };
        public static string[] EventTypes = new string[]
        {
            null,
            "Modifier",
            "Modifier",
            "Modifier",
            "Object",
            "Modifier",
            "Object",
            "Object",
            "Modifier",
            "Modifier",
            "Modifier",
            "Modifier",
            "Modifier",
            "Modifier",
            "Modifier",
            "Modifier",
            "Modifier",
            "Area",
            "Area",
            "Area",
            "Area",
            "Trigger",
            "Light",
            "Light",
            "Modifier",
            "Light",
            "Area",
            "Sound",
            "Boss",
            "StartPos",
            "StartPos",
            "StartPos",
            null,
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Object",
            "Object",
            "Object",
            "Goodies",
            "Goodies",
            "Ammo",
            "Goodies",
            "Goodies",
            "Gem",
            "Goodies",
            "Goodies",
            "Goodies",
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Ammo",
            "Object",
            "Object",
            "Spring",
            "PowerUp",
            "Spring",
            "Gem",
            "Gem",
            "Gem",
            "Gem",
            "Gem",
            "Object",
            "Ammo",
            "Gem",
            "Morph",
            "Goodies",
            "Goodies",
            "Shield",
            "Shield",
            "Shield",
            "PowerUp",
            "PowerUp",
            "Goodies",
            "Goodies",
            "SignPost",
            null,
            "SignPost",
            "SignPost",
            "Spring",
            "Spring",
            "Spring",
            "Goodies",
            "Goodies",
            "Goodies",
            "Spring",
            "Spring",
            "Spring",
            "Morph",
            "Trigger",
            "Goodies",
            "Gem",
            "Gem",
            "Gem",
            "Enemy",
            "Boss",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Object",
            "Object",
            "Enemy",
            "Boss",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Object",
            "Enemy",
            "Scenery",
            "Scenery",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Scenery",
            "Scenery",
            "Object",
            "PowerUp",
            "PowerUp",
            "PowerUp",
            "PowerUp",
            "PowerUp",
            "PowerUp",
            "Pinball",
            "Pinball",
            "Pinball",
            "Pinball",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Light",
            "Light",
            "Light",
            "Boss",
            "Enemy",
            "Object",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Food",
            "Enemy",
            "Enemy",
            "Trigger",
            "Trigger",
            "Trigger",
            "Trigger",
            "Gem",
            "Enemy",
            "Enemy",
            "Gem",
            "Object",
            "Sound",
            "Boss",
            "Enemy",
            "Enemy",
            "Enemy",
            "Boss",
            "Boss",
            "Boss",
            "Boss",
            "Object",
            "Object",
            "Object",
            "Object",
            "Trigger",
            "Scenery",
            "Platform",
            "Platform",
            "Platform",
            "Platform",
            "Platform",
            "Platform",
            "Object",
            null,
            "Object",
            "Scenery",
            "PowerUp",
            "PowerUp",
            "PowerUp",
            "Morph",
            "Object",
            "Spring",
            "Enemy",
            "Object",
            "Shield",
            "Object",
            "Object",
            "Area",
            "Object",
            "Object",
            "Scenery",
            "Trigger",
            "Boss",
            "Enemy",
            "Enemy",
            "Scenery",
            null,
            "Area",
            "Boss",
            "Area",
            null,
            "Object",
            "Area",
            "Area",
            "Boss",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            "Enemy",
            null,
            null,
            null,
        };

        [DataMember(Order = 0)]
        public int EventId { get; set; }
        [DataMember(Order = 1)]
        public Difficulty Difficulty  { get; set; }
    }
}
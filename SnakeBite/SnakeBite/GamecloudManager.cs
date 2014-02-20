using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SnakeBite;
using RestSharp;

namespace Gamecloud
{
    /// <summary>
    /// Gamecloud Manager handles all the connections & main functions related to Gamecloud
    /// </summary>
    public sealed class GamecloudManager
    {
        private string GAMECLOUD_ADDRESS = "http://54.217.213.109:8888";
        private string AUTH_TOKEN = "NO_AUTH";

        private static volatile GamecloudManager instance;
        private static object syncRoot = new object();

        // The private constructor
        private GamecloudManager() {}

        // The public hash libraries
        //The list of all dictionaries for storing different information
        public Dictionary<string, string> GetItemsDict = new Dictionary<string, string>();
        public Dictionary<string, string> GainItemsDict = new Dictionary<string, string>();
        public Dictionary<string, string> LoseItemsDict = new Dictionary<string, string>();
        public Dictionary<string, string> AskAchievementsDict = new Dictionary<string, string>();
        public Dictionary<string, string> GiveAchievementsDict = new Dictionary<string, string>();
        public Dictionary<string, string> TriggerEventsDict = new Dictionary<string, string>();
        public Dictionary<string, string> HasTriggeredEventsDict = new Dictionary<string, string>();

        
		// CallTypes, that can be used (in some situations, currently unused)
		public enum callTypes {
			GAIN_ITEM,
			ASK_ITEM,
			LOSE_ITEM,
			TRIGGER_EVENT,
			ASK_EVENT,
			GAIN_ACHIEVEMENT,
			ASK_ACHIEVEMENT
		};

		/// <summary>
		/// Creates the Gamecloud call for asking data in a proper JSON format
		/// </summary>
		/// <returns>The proper HashTable to send to Gamecloud</returns>
		/// <param name="hash">The hash for the given query</param>
		/// <param name="playerId">Player identifier.</param>
		/// <param name="characterId">Character identifier.</param>
		protected Hashtable createCall(string hash, string playerId, string characterId) 
		{
			// Create the hash table
			Hashtable data = new Hashtable();
			// Create the callType
			data.Add("callType", "gameDataSave");
			// Add the authkey
			data.Add("authkey", AUTH_TOKEN);
			// Add the hash
			data.Add("hash", hash);

			// If there is playerId
			if (playerId != null) 
			{
				// Add the player ID
				data.Add("playerId", playerId);
			}
			// If the characterId exists
			if (characterId != null) 
			{
				// Add the character ID
				data.Add("characterId", characterId);
			}

			// Then, return the data
			return data;
		}

		/// <summary>
		/// Creates the call for Asking if player has items
		/// </summary>
		/// <param name="hash">ASK hash</param>
		/// <param name="playerId">Player identifier</param>
		/// <param name="characterId">Character identifier</param>
		public void askItems(string hash, string playerId, string characterId)
		{

			// Create the call
			Hashtable data = createCall(hash, playerId, characterId);
			// Send the data to Gamecloud
			SendData(data);
		}

		/// <summary>
		/// Creates the call for giving a gainItem event for the player
		/// </summary>
		/// <param name="hash">gainItem hash</param>
		/// <param name="playerId">Player identifier.</param>
		/// <param name="characterId">Character identifier.</param>
		public void gainItem(string hash, string playerId, string characterId) 
		{
			// Create the call
			Hashtable data = createCall(hash, playerId, characterId);
			// Send the data to Gamecloud
			SendData(data);
		}

		/// <summary>
		/// Creates the call for giving a loseItem event for the player
		/// </summary>
		/// <param name="hash">loseItem hash.</param>
		/// <param name="playerId">Player identifier.</param>
		/// <param name="characterId">Character identifier.</param>
		public void loseItem(string hash, string playerId, string characterId)
		{
			// Create the call
			Hashtable data = createCall(hash, playerId, characterId);
			// Send the data to Gamecloud
			SendData(data);
		}

		/// <summary>
		/// Creates the triggerEvent call for gamecloud
		/// </summary>
		/// <param name="hash">triggerEvent hash.</param>
		/// <param name="playerId">Player identifier.</param>
		public void triggerEvent(string hash, string playerId)
		{
			// Create the call, no need for characterId so it is null
			Hashtable data = createCall(hash, playerId, null);
			// Send the data to Gamecloud
			SendData(data);
		}

		/// <summary>
		/// Asks if the player in question has received the event in question
		/// </summary>
		/// <param name="hash">askEvent hash.</param>
		/// <param name="playerId">Player identifier.</param>
		public void askEvent(string hash, string playerId)
		{
			// Create the call, no need for characterId so it is null
			Hashtable data = createCall(hash, playerId, null);
			// Send the data to Gamecloud
			SendData(data);
		}

		/// <summary>
		/// Creates the query for giving a gainAchievement event for the player
		/// </summary>
		/// <param name="hash">GainAchievememt hash.</param>
		/// <param name="playerId">Player identifier.</param>
		public void gainAchievement(string hash, string playerId) 
		{
			// Create the call, no need for characterId so it is null
			Hashtable data = createCall(hash, playerId, null);
			// Send the data to Gamecloud
			SendData(data);
		}

		/// <summary>
		/// Asks if the player has received the Achievement in question
		/// </summary>
		/// <param name="hash">ASK Achievement hash.</param>
		/// <param name="playerId">Player identifier.</param>
		public void askAchievement(string hash, string playerId)
		{
			// Create the call, no need for characterId so it is null
			Hashtable data = createCall(hash, playerId, null);
			// Send the data to Gamecloud
			SendData(data);
		}


		/// <summary>
		/// Sends the data in proper JSON format to the Gamecloud
		/// </summary>
		/// <param name="data">
		/// The properly formated data, done by using the createCall function with proper information.
		/// </param>
		public void SendData(Hashtable data) 
		{
            // Create the client
            var client = new RestClient();
            client.BaseUrl = GAMECLOUD_ADDRESS;

            var request = new RestRequest(Method.POST) ;
            string gainhash = "hgggbm1fgktke29";
            string askhash = "t9vcydmqs4u3ow29";
            string characterId = "TestCharacter33";
            string playerId = "TestPlayer88";

            // Create the event object
            EventClass eventClass = new EventClass(AUTH_TOKEN, askhash, playerId, characterId);

            // Then, send it 
            request.AddObject(eventClass);

            // Execute
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine(content);
 


		}

       

        /// <summary>
        /// Thread safe singleton based on http://msdn.microsoft.com/en-us/library/ff650316.aspx
        /// Will return the instance object of the singleton class or create it, if it does not exist
        /// </summary>
        public static GamecloudManager Instance
        {
            get
            {
                // If instance is null
                if (instance == null)
                {
                    // Lock the syncRoot
                    lock (syncRoot)
                    {
                        // If instance is still null
                        if (instance == null)
                        {
                            // Instantiate the class
                            instance = new GamecloudManager();
                        }
                    }
                }

                // Return the singleton instance
                return instance;

            } // End of get
        } // End of Instace()

    } // End of class Gamecloud

} // End of namespace Gamecloud
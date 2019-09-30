[
    '{{repeat(25)}}',
    {
      Username: '{{firstName("male")}}',
      Password: 'password',
      Gender: 'man',
      DateOfBirth: '{{date(new Date(1950,0,1), new Date(1999, 11, 31), "YYYY-MM-dd")}}',
      Created: '{{date(new Date(2019,1,1), new Date(2019, 7, 10), "YYYY-MM-dd")}}',
      LastActive: function(){ return this.Created; },
      City: 'berlin',
      Country: 'germany',
      
      Growth: '{{integer(150, 200)}}',
      EyeColor: 'green',
      HairColor: 'blond',
      MaritalStatus: 'single',
      Education: 'higher education',
      Profession: 'teacher',
      Children : 'no',
      Language: 'english',
      
      Motto: '{{lorem(1, "sentences")}}',
      Description: '{{lorem(1, "paragraphs")}}',
      Personality: '{{lorem(1, "sentences")}}',
      LookingFor: '{{lorem(1, "sentences")}}',
      
      Interests: '{{lorem(1, "paragraphs")}}',
      FreeTime: '{{lorem(1, "sentences")}}',
      Sport: '{{lorem(1, "sentences")}}',
      Movies: '{{lorem(1, "sentences")}}',
      Music: '{{lorem(1, "sentences")}}',
      
      ILike: '{{lorem(1, "sentences")}}',
      IdoNotLike: '{{lorem(1, "sentences")}}',
      MakesMeLaugh: '{{lorem(1, "sentences")}}',
      ItFeelsBestIn: '{{lorem(1, "sentences")}}',
      FriendWouldDescribeMe: '{{lorem(1, "sentences")}}',
      
      Photos: [
        {
          url: function(num) {
            return 'https://randomuser.me/api/portraits/men/'+ num.integer(1,99) + '.jpg';
          },
          isMain: true,
          DateAdded: '{{date(new Date(2019,1,1), new Date(2019, 7, 10), "YYYY-MM-dd")}}',
          description: '{{lorem()}}'
        }
      ]
    
    }
  ]
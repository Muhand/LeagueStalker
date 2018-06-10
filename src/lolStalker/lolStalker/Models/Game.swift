//
//  Game.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/8/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation

class Game {
    var Team1: Team?
    var Team2: Team?
    
    init(team1: Team, team2: Team) {
        self.Team1 = team1
        self.Team2 = team2
    }
}

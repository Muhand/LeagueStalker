//
//  Team.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/8/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation

class Team {
    let TEAMSIZE = 5
    var players: [Player] = []

    init(players: Player...) throws {
        if (players.count > 5 || players.count < 5) {
            throw CustomErrors.TeamCountNotMet("You need to have a max of 5 players in a team")
        } else {
            self.players = players
        }
    }
}

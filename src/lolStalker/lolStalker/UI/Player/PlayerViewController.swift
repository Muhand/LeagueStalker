//
//  PlayerViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/8/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class PlayerViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let playerView: PlayerView = {
        let view = PlayerView()
        
//        var player: Player = Player()
//        player.summonerName = "WarDesigner"
//        player.championName = "Aatrox"
//        player.backgroundImage = #imageLiteral(resourceName: "tempChampion")
//        player.profileImage = #imageLiteral(resourceName: "tempProfile")
//        player.spell1 = #imageLiteral(resourceName: "tempSpell1")
//        player.spell2 = #imageLiteral(resourceName: "tempSpell2")
        
//        var team: Team
        
//        do {
//            team = try Team(players: player, player, player, player, player)
//            view.game = Game(team1: team, team2: team)
//        } catch {
//            print(error)
//        }
        
        
        return view
    }()
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        setupView()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        view.backgroundColor = UIColor(hex: "#010A13")
//        view.backgroundColor = .green
        hideKeyboardWhenTappedAround()
    }
    
    func setupSubViews() {
        view.addSubview(playerView)
        
        playerView.delegate = self
    }
    
    func setupConstraints() {
        playerView.translatesAutoresizingMaskIntoConstraints = false
        
        playerView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        playerView.bottomAnchor.constraint(equalTo: view.bottomAnchor).isActive = true
        playerView.heightAnchor.constraint(equalTo: view.heightAnchor, constant: -UIApplication.shared.statusBarFrame.height).isActive = true
        playerView.widthAnchor.constraint(equalTo: view.widthAnchor, constant: -Helper.getWidthOf(xdWidth: 24, referenceWidth: nil, originalWidth: nil)).isActive = true
        
    }
    
    func setupMargins() {
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
    
}

extension PlayerViewController: PlayerViewDelegate {
    func cancelPressed(form: PlayerView) {
        dismiss(animated: true, completion: nil)
    }
    
    func didSetPlayer(player: Player, form: PlayerView) {
        
    }
    
    
}

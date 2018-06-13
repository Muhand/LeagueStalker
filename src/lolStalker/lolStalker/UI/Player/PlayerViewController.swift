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
    let parentScrollView: UIScrollView = {
        let view = UIScrollView()
        view.backgroundColor = .red
        return view
    }()
    
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
//        parentScrollView.addSubview(playerView)
        
        playerView.delegate = self
    }
    
    func setupConstraints() {
        parentScrollView.translatesAutoresizingMaskIntoConstraints = false
        playerView.translatesAutoresizingMaskIntoConstraints = false
        
//        view.addConstraintsWithFormat(format: "V:|[v0]|", views: parentScrollView)
//        view.addConstraintsWithFormat(format: "H:|[v0]|", views: parentScrollView)
        
//        parentScrollView.addConstraintsWithFormat(format: "H:|-\(Helper.getWidthOf(xdWidth: 12, referenceWidth: nil, originalWidth: nil))-[v0]-\(Helper.getWidthOf(xdWidth: 12, referenceWidth: nil, originalWidth: nil))-|", views: playerView)
//        parentScrollView.addConstraintsWithFormat(format: "H:|[v0]|", views: playerView)
//        parentScrollView.addConstraintsWithFormat(format: "V:|[v0]|", views: playerView)
        
//        parentScrollView.addConstraintsWithFormat(format: "V:|-\(UIApplication.shared.statusBarFrame.height)-[v0]|", views: playerView)
        
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
